namespace CRUD
{
    partial class CRUD
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
            panel1 = new Panel();
            btnDelete = new Button();
            btnAtualizar = new Button();
            label7 = new Label();
            label6 = new Label();
            dataGridView = new DataGridView();
            dataNasc = new DateTimePicker();
            btnCadastrar = new Button();
            pbFoto = new PictureBox();
            label5 = new Label();
            txtSenha = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTelefone = new TextBox();
            txtEmail = new TextBox();
            txtSobrenome = new TextBox();
            txtNome = new TextBox();
            btnFoto = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnFoto);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAtualizar);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dataGridView);
            panel1.Controls.Add(dataNasc);
            panel1.Controls.Add(btnCadastrar);
            panel1.Controls.Add(pbFoto);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtSenha);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtTelefone);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtSobrenome);
            panel1.Controls.Add(txtNome);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 632);
            panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(392, 176);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 62);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "APAGAR";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(392, 83);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(107, 62);
            btnAtualizar.TabIndex = 16;
            btnAtualizar.Text = "ATUALIZAR";
            btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 395);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 15;
            label7.Text = "Data Nascimento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(315, 24);
            label6.Name = "label6";
            label6.Size = new Size(242, 33);
            label6.TabIndex = 14;
            label6.Text = "Tela de Cadastro";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(72, 472);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(668, 150);
            dataGridView.TabIndex = 13;
            // 
            // dataNasc
            // 
            dataNasc.Location = new Point(73, 413);
            dataNasc.Name = "dataNasc";
            dataNasc.Size = new Size(287, 23);
            dataNasc.TabIndex = 12;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(523, 395);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(217, 45);
            btnCadastrar.TabIndex = 11;
            btnCadastrar.Text = "CADASTRAR";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // pbFoto
            // 
            pbFoto.Location = new Point(523, 83);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(217, 232);
            pbFoto.TabIndex = 10;
            pbFoto.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 329);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(73, 347);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(287, 23);
            txtSenha.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 263);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 7;
            label4.Text = "Telefone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 196);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 130);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 5;
            label2.Text = "Sobrenome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 56);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(73, 281);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(287, 23);
            txtTelefone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(73, 215);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(287, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtSobrenome
            // 
            txtSobrenome.Location = new Point(73, 149);
            txtSobrenome.Name = "txtSobrenome";
            txtSobrenome.Size = new Size(287, 23);
            txtSobrenome.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(73, 83);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(287, 23);
            txtNome.TabIndex = 0;
            // 
            // btnFoto
            // 
            btnFoto.Location = new Point(524, 329);
            btnFoto.Name = "btnFoto";
            btnFoto.Size = new Size(216, 45);
            btnFoto.TabIndex = 18;
            btnFoto.Text = "Escolher Foto";
            btnFoto.UseVisualStyleBackColor = true;
            btnFoto.Click += btnFoto_Click;
            // 
            // CRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 632);
            Controls.Add(panel1);
            Name = "CRUD";
            Text = "Tela de Cadastro";
            Load += CRUD_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSobrenome;
        private TextBox txtNome;
        private Label label5;
        private TextBox txtSenha;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTelefone;
        private TextBox txtEmail;
        private PictureBox pbFoto;
        private Button btnCadastrar;
        private DateTimePicker dataNasc;
        private DataGridView dataGridView;
        private Label label6;
        private Label label7;
        private Button btnAtualizar;
        private Button btnDelete;
        private Button btnFoto;
    }
}
