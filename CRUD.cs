using MySql.Data.MySqlClient;
using System.Data;

namespace CRUD
{
    public partial class CRUD : Form
    {
        // Criando a variável que pega a conexão com o banco de dados.
        string stgCon = "Server=127.0.0.1;Port=3307;Database=Crud;uid=root;Pwd=senacJBQ;";
        public CRUD()
        {
            InitializeComponent();
            Limpar();
            dataGridView.Refresh();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            Conexao();
            Atualizar();
        }

        private void Conexao()
        {

            //byte[] image = (byte[])(["Foto"]);

            //Instância da Conexão
            MySqlConnection conexao = new MySqlConnection(stgCon);

            //Abrindo a conexão
            conexao.Open();

            MessageBox.Show("Conectado com sucesso! ");

            // Criando nosso consulta no banco 
            string sql = "SELECT * FROM CADASTRO;";

            // Instanciando o MySqlCommand responsável por pegar
            // a conexão com o banco a instrução SQL
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            // Mapear as entidades 
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            // Construi os dados em forma de tabela
            DataTable dt = new DataTable();

            // Preenche o Datatable
            da.Fill(dt);

            // Passa os dados para dentro do DataGridView
            dataGridView.DataSource = dt;

            // Fecha a conexão
            conexao.Close();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }

        private void Cadastrar()
        {
            string query = "INSERT INTO CADASTRO " +
                "(Id, Nome, Sobrenome, Email, Telefone, Senha, DataNascimento, Foto)" +
                "VALUES (@Id, @Nome, @Sobrenome, @Email, @Telefone, @Senha, @DataNasc, @Foto);";


            MySqlConnection con = new MySqlConnection(stgCon);
            con.Open();

            MySqlCommand cmd = new MySqlCommand(query, con);

            DateTime dataNasc = new DateTime(2025, 03, 27);

            cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text.ToString());
            cmd.Parameters.AddWithValue("@Sobrenome", txtSobrenome.Text.ToString());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
            cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text.ToString());
            cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.ToString());
            cmd.Parameters.AddWithValue("@DataNasc", dataNasc);
            cmd.Parameters.AddWithValue("@Foto", pbFoto.ToString());

            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Cadastro realizado com sucesso!");
            con.Close();

        }

        private void Atualizar()
        {
            string query = "UPDATE CADASTRO SET @ID, @Nome, @Sobrenome, @Email, @Telefone, @Senha, @DataNasc, @Foto";

            MySqlConnection con = new MySqlConnection(stgCon);
            con.Open();

            MySqlCommand cmd = new MySqlCommand(query, con);

            DateTime dataNasc = new DateTime(2025, 03, 27);

            cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text.ToString());
            cmd.Parameters.AddWithValue("@Sobrenome", txtSobrenome.Text.ToString());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
            cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text.ToString());
            cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.ToString());
            cmd.Parameters.AddWithValue("@DataNasc", dataNasc);
            cmd.Parameters.AddWithValue("@Foto", pbFoto.ToString());

            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void Limpar()
        {
            dataGridView.ClearSelection();
        }


        private void CarregarImagem()
        {
            using (OpenFileDialog openImage = new OpenFileDialog())
            {
               if(openImage.ShowDialog() == DialogResult.OK)
                    pbFoto.Text = openImage.FileName;
                    pbFoto.Image = Image.FromFile(openImage.FileName);
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            CarregarImagem();
        }
    }
}
