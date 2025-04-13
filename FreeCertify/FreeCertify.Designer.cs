namespace FreeCertify
{
    partial class FreeCertify
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            button1 = new Button();
            listBox1 = new ListBox();
            rictxtvalidacion = new RichTextBox();
            label3 = new Label();
            btnobtenercert = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label2 = new Label();
            label1 = new Label();
            txtdominio = new TextBox();
            txtmail = new TextBox();
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            txtpasword = new TextBox();
            label6 = new Label();
            button3 = new Button();
            btncertgen = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            label7 = new Label();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            sobreEsteProgramaToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(rictxtvalidacion);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnobtenercert);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtdominio);
            groupBox1.Controls.Add(txtmail);
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(685, 392);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(659, 74);
            button1.Name = "button1";
            button1.Size = new Size(20, 23);
            button1.TabIndex = 16;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(17, 99);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(662, 49);
            listBox1.TabIndex = 15;
            // 
            // rictxtvalidacion
            // 
            rictxtvalidacion.BorderStyle = BorderStyle.FixedSingle;
            rictxtvalidacion.Location = new Point(17, 198);
            rictxtvalidacion.Name = "rictxtvalidacion";
            rictxtvalidacion.ScrollBars = RichTextBoxScrollBars.Vertical;
            rictxtvalidacion.Size = new Size(662, 188);
            rictxtvalidacion.TabIndex = 8;
            rictxtvalidacion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 177);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 7;
            label3.Text = "Valores de validación";
            // 
            // btnobtenercert
            // 
            btnobtenercert.Location = new Point(114, 151);
            btnobtenercert.Name = "btnobtenercert";
            btnobtenercert.Size = new Size(492, 23);
            btnobtenercert.TabIndex = 6;
            btnobtenercert.Text = "Obtener verificación";
            btnobtenercert.UseVisualStyleBackColor = true;
            btnobtenercert.Click += btnobtenercert_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(253, 0);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(222, 19);
            radioButton2.TabIndex = 5;
            radioButton2.Text = "Validación HTTP-01 (HTTP Challenge)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(34, -1);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(212, 19);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "Validación DNS-01 (DNS Challenge)";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 56);
            label2.Name = "label2";
            label2.Size = new Size(175, 15);
            label2.TabIndex = 3;
            label2.Text = "Dominio web (midominio.com)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 17);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 2;
            label1.Text = "Correo Electrónico";
            // 
            // txtdominio
            // 
            txtdominio.Location = new Point(17, 74);
            txtdominio.Name = "txtdominio";
            txtdominio.Size = new Size(636, 23);
            txtdominio.TabIndex = 1;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(17, 33);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(662, 23);
            txtmail.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txtpasword);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btncertgen);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(12, 420);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 382);
            panel1.TabIndex = 17;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(13, 257);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(656, 122);
            richTextBox1.TabIndex = 25;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(612, 10);
            button2.Name = "button2";
            button2.Size = new Size(57, 23);
            button2.TabIndex = 23;
            button2.Text = "Generar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtpasword
            // 
            txtpasword.Location = new Point(466, 11);
            txtpasword.Name = "txtpasword";
            txtpasword.Size = new Size(140, 23);
            txtpasword.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 41);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 20;
            label6.Text = "Certificado CRT";
            // 
            // button3
            // 
            button3.Location = new Point(187, 229);
            button3.Name = "button3";
            button3.Size = new Size(288, 23);
            button3.TabIndex = 19;
            button3.Text = "Ver certificados";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btncertgen
            // 
            btncertgen.Location = new Point(15, 14);
            btncertgen.Name = "btncertgen";
            btncertgen.Size = new Size(218, 23);
            btncertgen.TabIndex = 18;
            btncertgen.Text = "Generar certificado";
            btncertgen.UseVisualStyleBackColor = true;
            btncertgen.Click += btncertgen_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(15, 152);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox4.Size = new Size(654, 71);
            textBox4.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(15, 60);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(654, 71);
            textBox3.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 134);
            label5.Name = "label5";
            label5.Size = new Size(135, 15);
            label5.TabIndex = 15;
            label5.Text = "Llave del certificado KEY";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(397, 14);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 22;
            label7.Text = "Contraseña";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(709, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobreEsteProgramaToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // sobreEsteProgramaToolStripMenuItem
            // 
            sobreEsteProgramaToolStripMenuItem.Name = "sobreEsteProgramaToolStripMenuItem";
            sobreEsteProgramaToolStripMenuItem.Size = new Size(183, 22);
            sobreEsteProgramaToolStripMenuItem.Text = "Sobre este programa";
            sobreEsteProgramaToolStripMenuItem.Click += sobreEsteProgramaToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 808);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FreeCertify";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtmail;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private Label label1;
        private TextBox txtdominio;
        private RichTextBox rictxtvalidacion;
        private Label label3;
        private Button btnobtenercert;
        private ErrorProvider errorProvider1;
        private Button button1;
        private ListBox listBox1;
        private Panel panel1;
        private Label label6;
        private Button button3;
        private Button btncertgen;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label5;
        private Button button2;
        private TextBox txtpasword;
        private Label label7;
        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem sobreEsteProgramaToolStripMenuItem;
    }
}
