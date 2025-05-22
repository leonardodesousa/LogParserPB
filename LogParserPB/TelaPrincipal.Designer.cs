namespace LogParserPB
{
    partial class TelaPrincipal
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
            txtBxEntrada = new TextBox();
            txtBxSaida = new TextBox();
            LabelEntrada = new Label();
            label1 = new Label();
            btnAnalisar = new Button();
            checkBoxJava = new CheckBox();
            CheckBoxPb = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBxEntrada
            // 
            txtBxEntrada.Location = new Point(242, 143);
            txtBxEntrada.Margin = new Padding(3, 4, 3, 4);
            txtBxEntrada.Name = "txtBxEntrada";
            txtBxEntrada.Size = new Size(545, 27);
            txtBxEntrada.TabIndex = 0;
            txtBxEntrada.TextChanged += txtBxEntrada_TextChanged;
            // 
            // txtBxSaida
            // 
            txtBxSaida.Location = new Point(242, 223);
            txtBxSaida.Margin = new Padding(3, 4, 3, 4);
            txtBxSaida.Name = "txtBxSaida";
            txtBxSaida.Size = new Size(545, 27);
            txtBxSaida.TabIndex = 1;
            txtBxSaida.TextChanged += txtBxSaida_TextChanged;
            // 
            // LabelEntrada
            // 
            LabelEntrada.AutoSize = true;
            LabelEntrada.Location = new Point(143, 147);
            LabelEntrada.Name = "LabelEntrada";
            LabelEntrada.Size = new Size(60, 20);
            LabelEntrada.TabIndex = 2;
            LabelEntrada.Text = "Entrada";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 233);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 3;
            label1.Text = "Saída";
            // 
            // btnAnalisar
            // 
            btnAnalisar.Location = new Point(243, 63);
            btnAnalisar.Margin = new Padding(3, 4, 3, 4);
            btnAnalisar.Name = "btnAnalisar";
            btnAnalisar.Size = new Size(114, 60);
            btnAnalisar.TabIndex = 4;
            btnAnalisar.Text = "Analisar";
            btnAnalisar.UseVisualStyleBackColor = true;
            btnAnalisar.Click += btnAnalisar_Click;
            // 
            // checkBoxJava
            // 
            checkBoxJava.AutoSize = true;
            checkBoxJava.Location = new Point(25, 60);
            checkBoxJava.Margin = new Padding(3, 4, 3, 4);
            checkBoxJava.Name = "checkBoxJava";
            checkBoxJava.Size = new Size(59, 24);
            checkBoxJava.TabIndex = 5;
            checkBoxJava.Text = "Java";
            checkBoxJava.UseVisualStyleBackColor = true;
            checkBoxJava.CheckedChanged += checkBoxJava_CheckedChanged;
            // 
            // CheckBoxPb
            // 
            CheckBoxPb.AutoSize = true;
            CheckBoxPb.Location = new Point(25, 97);
            CheckBoxPb.Margin = new Padding(3, 4, 3, 4);
            CheckBoxPb.Name = "CheckBoxPb";
            CheckBoxPb.Size = new Size(118, 24);
            CheckBoxPb.TabIndex = 6;
            CheckBoxPb.Text = "PowerBuilder";
            CheckBoxPb.UseVisualStyleBackColor = true;
            CheckBoxPb.CheckedChanged += CheckBoxPb_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAnalisar);
            groupBox1.Controls.Add(CheckBoxPb);
            groupBox1.Controls.Add(checkBoxJava);
            groupBox1.Location = new Point(409, 291);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(378, 181);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Origem do log";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 509);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(LabelEntrada);
            Controls.Add(txtBxSaida);
            Controls.Add(txtBxEntrada);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaPrincipal";
            Text = "Log Analyzer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBxEntrada;
        private TextBox txtBxSaida;
        private Label LabelEntrada;
        private Label label1;
        private Button btnAnalisar;
        private CheckBox checkBoxJava;
        private CheckBox CheckBoxPb;
        private GroupBox groupBox1;
    }
}
