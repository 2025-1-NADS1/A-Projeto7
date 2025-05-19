namespace FormsCliente
{
    partial class Form1
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
            txtComando = new TextBox();
            lblComando = new Label();
            txtResposta = new TextBox();
            lblResposta = new Label();
            btnEnviar = new Button();
            btnLimpar = new Button();
            SuspendLayout();
            // 
            // txtComando
            // 
            txtComando.Location = new Point(228, 16);
            txtComando.Margin = new Padding(3, 4, 3, 4);
            txtComando.Name = "txtComando";
            txtComando.Size = new Size(494, 27);
            txtComando.TabIndex = 0;
            txtComando.TextChanged += txtComando_TextChanged;
            // 
            // lblComando
            // 
            lblComando.AutoSize = true;
            lblComando.Font = new Font("Segoe UI", 12F);
            lblComando.ForeColor = SystemColors.MenuHighlight;
            lblComando.Location = new Point(14, 12);
            lblComando.Name = "lblComando";
            lblComando.Size = new Size(208, 28);
            lblComando.TabIndex = 1;
            lblComando.Text = "Entre com o Comando";
            // 
            // txtResposta
            // 
            txtResposta.ForeColor = SystemColors.Window;
            txtResposta.Location = new Point(14, 104);
            txtResposta.Margin = new Padding(3, 4, 3, 4);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.ReadOnly = true;
            txtResposta.ScrollBars = ScrollBars.Vertical;
            txtResposta.Size = new Size(675, 295);
            txtResposta.TabIndex = 2;
            txtResposta.TextChanged += txtResposta_TextChanged;
            // 
            // lblResposta
            // 
            lblResposta.AutoSize = true;
            lblResposta.Font = new Font("Segoe UI", 12F);
            lblResposta.ForeColor = SystemColors.MenuHighlight;
            lblResposta.Location = new Point(14, 72);
            lblResposta.Name = "lblResposta";
            lblResposta.Size = new Size(90, 28);
            lblResposta.TabIndex = 3;
            lblResposta.Text = "Resposta";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(603, 425);
            btnEnviar.Margin = new Padding(3, 4, 3, 4);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(86, 31);
            btnEnviar.TabIndex = 4;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.DimGray;
            btnLimpar.Font = new Font("Segoe UI", 9F);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(14, 408);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(181, 48);
            btnLimpar.TabIndex = 5;
            btnLimpar.Text = "Limpar Respota";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 472);
            Controls.Add(btnLimpar);
            Controls.Add(btnEnviar);
            Controls.Add(lblResposta);
            Controls.Add(txtResposta);
            Controls.Add(lblComando);
            Controls.Add(txtComando);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtComando;
        private Label lblComando;
        private TextBox txtResposta;
        private Label lblResposta;
        private Button btnEnviar;
        private Button btnLimpar;
    }
}
