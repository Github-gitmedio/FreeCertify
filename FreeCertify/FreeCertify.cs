
using Certes;
using Certes.Acme;
using Certes.Acme.Resource;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FreeCertify
{
    public partial class FreeCertify : Form
    {
        public FreeCertify()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            this.Size = new Size(725, 470);
        }

        IOrderContext order_;
        private AcmeContext acme;
        private List<(IAuthorizationContext Authz, IChallengeContext Challenge, string Domain, string DnsTxt, IOrderContext orders)> dnsChallenges = new List<(IAuthorizationContext Authz, IChallengeContext Challenge, string Domain, string DnsTxt, IOrderContext orders)>();
        private string NombreDominio = "";
        private void btnobtenercert_Click(object sender, EventArgs e)
        {
            if (EsEmailValido(txtmail.Text))
            {
                errorProvider1.SetError(txtmail, null);
                if (listBox1.Items.Count > 0)
                {
                    errorProvider1.SetError(listBox1, null);
                    if (radioButton1.Checked)
                    {
                        BuscarDominioPrincipal();
                        GenerateCertificateAsync();
                    }
                }
                else
                {
                    errorProvider1.SetError(listBox1, "No existe ningun dominio web");
                }

            }
            else
            {
                errorProvider1.SetError(txtmail, "Correo electrónico no válido");
            }

        }


        public async Task GenerateCertificateAsync()
        {

            try
            {
                var key = KeyFactory.NewKey(KeyAlgorithm.ES256);
                acme = new AcmeContext(WellKnownServers.LetsEncryptV2);//LetsEncryptV2                                         // Crear una nueva cuenta ACME
                string[] ListDomanin = listBox1.Items.Cast<string>().ToArray();
                var account = await acme.NewAccount(txtmail.Text, termsOfServiceAgreed: true);
                order_ = await acme.NewOrder(ListDomanin);
                // Obtener el desafío DNS
                var authzList = await order_.Authorizations();
                var sb = new StringBuilder(256);
                dnsChallenges = new List<(IAuthorizationContext Authz, IChallengeContext Challenge, string Domain, string DnsTxt, IOrderContext orders)>();
                sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang3082\deflangfe3082\deftab708{\fonttbl{\f0\fswiss\fprq2\fcharset0 Calibri;}}
{\*\generator Riched20 10.0.19041}{\*\mmathPr\mnaryLim0\mdispDef1\mwrapIndent1440 }\viewkind4\uc1 \pard\widctlpar\sl276\slmult1");
                foreach (var authz in authzList)
                {
                    // Obtener el dominio asociado a la autorización
                    var dominio = (await authz.Resource()).Identifier.Value;

                    // Obtener el desafío DNS para la autorización actual
                    var dnsChallenge = await authz.Dns();
                    var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);
                    sb.AppendLine(@"\b\f0\fs22 Nombre registro:\b0" + string.Format(" {0}", "_acme-challenge." + dominio) + @"\par\b Valor registro:\b0 " + string.Format("{0}", dnsTxt) + @"\par \par");


                    dnsChallenges.Add((authz, dnsChallenge, dominio, dnsTxt, order_));
                }
                sb.Append(@"}");
                rictxtvalidacion.Rtf = sb.ToString();
                if (sb.ToString().Length > 0)
                {
                    btnobtenercert.Enabled = false;
                    button1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    //562; 632
                    this.Size = new Size(725, 847);
                    txtpasword.Text = GeneratePassword(20, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede volver a generar para {string.Join(",", listBox1.Items.Cast<string>().ToArray())}, " + ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public async Task ValidaryGenerar()
        {
            if (txtpasword.Text.Length > 0)
            {
                btncertgen.Text = "Volver a solicitar";
                var validationTasks = dnsChallenges.Select(ValidateChallenge);
                await Task.WhenAll(validationTasks);
                var privateKey = KeyFactory.NewKey(KeyAlgorithm.RS256);
                var cert = await order_.Generate(
                    new CsrInfo
                    {
                        //CountryName = "BO",
                        //State = "La Paz",
                        //Locality = "Nuestra señora de La Paz",
                        //Organization = "My Company",
                        //OrganizationUnit = "IT",
                        //CommonName = domain,
                    },
                    privateKey);

                var pfxBuilder = cert.ToPfx(privateKey);

                var pfx = pfxBuilder.Build("MyCer-tFile", txtpasword.Text);
                var certPem = cert.ToPem();
                var privateKeyPem = privateKey.ToPem();
                // Guardar el certificado en un archivo .pfx
                // var pfxBytes = pfx;
                textBox3.Text = certPem;
                textBox4.Text = privateKeyPem;
                if (certPem != "" && privateKeyPem != "")
                {
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                }
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FreeCertify-donload", NombreDominio) + Path.DirectorySeparatorChar;
                if (System.IO.Directory.Exists(path) == false)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string Certpfx = path + NombreDominio + ".pfx";
                string CertKey = path + NombreDominio + ".key.pem";
                string CertCRT = path + NombreDominio + ".crt.pem";
                string Paswordpfx = path + "Password.txt";
                await File.WriteAllBytesAsync(Certpfx, pfx);
                X509Certificate2 certificate = new X509Certificate2(Certpfx, txtpasword.Text, X509KeyStorageFlags.Exportable);
                // Extraer el certificado en formato PEM (.crt)
                string crtContent = ExportCertificateToPem(certificate);
                await File.WriteAllTextAsync(CertCRT, crtContent);
                // Extraer la clave privada en formato PEM (.key)
                string keyContent = ExportPrivateKeyToPem(certificate);
                await File.WriteAllTextAsync(CertKey, keyContent);
                await File.WriteAllTextAsync(Paswordpfx, txtpasword.Text);
            }
            else
            {
                MessageBox.Show("Establesca contraseña", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        static string ExportCertificateToPem(X509Certificate2 certificate)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(certificate.Export(X509ContentType.Cert)));
            builder.AppendLine("-----END CERTIFICATE-----");
            return builder.ToString();
        }

        static string ExportPrivateKeyToPem(X509Certificate2 certificate)
        {

            if (!certificate.HasPrivateKey)
            {
                throw new InvalidOperationException("El certificado no contiene una clave privada.");
            }

            if (certificate.GetRSAPrivateKey() != null)
            {
                // Clave RSA
                RSA privateKey = certificate.GetRSAPrivateKey();
                byte[] privateKeyBytes = privateKey.ExportRSAPrivateKey();
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("-----BEGIN RSA PRIVATE KEY-----");
                builder.AppendLine(Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END RSA PRIVATE KEY-----");
                return builder.ToString();
            }
            else if (certificate.GetECDsaPrivateKey() != null)
            {
                // Clave ECDSA
                ECDsa privateKey = certificate.GetECDsaPrivateKey();
                byte[] privateKeyBytes = privateKey.ExportECPrivateKey();
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("-----BEGIN EC PRIVATE KEY-----");
                builder.AppendLine(Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END EC PRIVATE KEY-----");
                return builder.ToString();
            }
            else
            {
                throw new InvalidOperationException("No se pudo obtener la clave privada (RSA o ECDSA).");
            }
        }

        private static string GeneratePassword(int length, bool includeUppercase = true, bool includeDigits = true, bool includeSpecialChars = true)
        {
            string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%&()_-+=[]{}|<>?";

            if (length < 8)
            {
                throw new ArgumentException("La longitud de la contraseña debe ser al menos 8 caracteres.");
            }

            // Crear un conjunto de caracteres permitidos
            var validChars = new StringBuilder(LowercaseLetters);
            if (includeUppercase) validChars.Append(UppercaseLetters);
            if (includeDigits) validChars.Append(Digits);
            if (includeSpecialChars) validChars.Append(SpecialCharacters);

            // Usar RandomNumberGenerator para mayor seguridad
            var randomBytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            // Convertir los bytes en caracteres
            var password = new StringBuilder(length);
            foreach (byte b in randomBytes)
            {
                password.Append(validChars[b % validChars.Length]);
            }

            return password.ToString();
        }

        private async Task ValidateChallenge((IAuthorizationContext authz, IChallengeContext dnsChallenge, string domain, string dnsTxt, IOrderContext orders) challenge)
        {
            var (authz, dnsChallenge, domain, dnsTxt, order) = challenge;
            // Validar el desafío DNS
            await dnsChallenge.Validate();
            var sb = new StringBuilder(256);
            sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang3082\deflangfe3082\deftab708{\fonttbl{\f0\fswiss\fprq2\fcharset0 Calibri;}}
{\colortbl ;\red255\green0\blue0;\red0\green176\blue80;}
{\*\generator Riched20 10.0.19041}{\*\mmathPr\mnaryLim0\mdispDef1\mwrapIndent1440 }\viewkind4\uc1 
\pard\widctlpar\sl276\slmult1");
            // Esperar a que el desafío sea validado
            while (true)
            {
                var status = await dnsChallenge.Resource();
                if (status.Status == ChallengeStatus.Valid)
                {
                    sb.AppendLine(@"\cf2\b OK\cf0 :\b0 " + $"Desafío DNS válidado para {domain}" + @"");
                    //errorProvider1.Icon = SystemIcons.Information;
                    //errorProvider1.SetError(label8, $"Desafío DNS válidado para {domain}");
                    //label8.Text =
                    // MessageBox.Show($"Desafío DNS validado para {domain}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                else if (status.Status == ChallengeStatus.Invalid)
                {
                    sb.AppendLine(@"\cf1\b\f0\fs18 Error\cf0 : \b0 " + $"El desafío DNS no se pudo validar para {domain}." + @"");
                    //errorProvider1.SetError(label8, $"El desafío DNS no se pudo validar para {domain}.");
                    //label8.Text = $"El desafío DNS no se pudo validar para {domain}.";
                    //  MessageBox.Show(, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                sb.Append("}");
                AgregarLineaRTF(sb.ToString());
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        void AgregarLineaRTF(string rtfTexto)
        {
            richTextBox1.Select(richTextBox1.TextLength, 0);
            int inicio = richTextBox1.TextLength;
            richTextBox1.SelectedRtf = rtfTexto;
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.ScrollToCaret();
        }
        public static bool EsDomainValido(String Dominio, bool notsubdomai = false)
        {
            if (string.IsNullOrWhiteSpace(Dominio))
                return false;

            string patron = @"^(?:[a-zA-Z0-9-]+\.)?[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{2,}$";
            string patron2 = @"^[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{2,}$";
            if (notsubdomai)
                return Regex.IsMatch(Dominio, patron2);
            else
                return Regex.IsMatch(Dominio, patron);
        }
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string patron = @"^[a-z0-9._%+-]+@[a-z0-9-]+(\.[a-z0-9-]+)*\.[a-z]{2,}$";


            return Regex.IsMatch(email, patron, RegexOptions.IgnoreCase);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EsDomainValido(txtdominio.Text))
            {
                if (listBox1.Items.Cast<string>().Where(item => item == txtdominio.Text).Count() > 0)
                {
                    MessageBox.Show("Ya existe un dominio\n con el nombre:(" + txtdominio.Text + ")", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdominio.Text = "";
                }
                else
                {
                    if (listBox1.Items.Count == 0)
                    {
                        if (EsDomainValido(txtdominio.Text))
                        {
                            listBox1.Items.Add("www." + txtdominio.Text);
                        }
                    }
                    listBox1.Items.Add(txtdominio.Text);
                    txtdominio.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Dominio no válido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDominioPrincipal()
        {
            foreach (String Item in listBox1.Items)
            {
                if (EsDomainValido(Item, true))
                {
                    NombreDominio = Item;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtpasword.Text = GeneratePassword(12, includeUppercase: true, includeDigits: true, includeSpecialChars: true); ;
        }

        private void btncertgen_Click(object sender, EventArgs e)
        {
            ValidaryGenerar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FreeCertify-donload", NombreDominio) + Path.DirectorySeparatorChar;
                var proceso = new Process();
                proceso.StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };
                proceso.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void sobreEsteProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 Desct = new AboutBox1();
            Desct.ShowDialog();
        }
    }
}
