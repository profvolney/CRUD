using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
#region Namespace CRUD
namespace CRUD
{
    #region classe que herda da classe Form
    public partial class CRUD : Form
    {
        #region ConnectionString
        // Criando a vari�vel que pega a conex�o com o banco de dados.
        string stgCon = "Server=127.0.0.1;Port=3306;Database=Crud;uid=root;Pwd=;";
        #endregion

        #region Construtor
        // Construtor
        public CRUD()
        {
            // M�todo para inicializar o Formul�rio
            InitializeComponent();
            // M�todo para limpar o DataGridView
            Limpar();
            // Atualiza o DataGridView
            dataGridView.Refresh();
            // Carrega o DataGridView
            CarregarDataGridView();
        }
        #endregion
        
        #region Load
        // M�todo Load que serve para carregamento de m�todos quando a aplica��o � carregada
        private void CRUD_Load(object sender, EventArgs e)
        {
            // Carrega o m�todo faz conex�o no banco de dados.
            Conexao();

            // Se n�o a foto n�o for selecionada informa o usu�rio
            // que precisa fazer o upload da foto primeiro.
            if (string.IsNullOrEmpty(pbFoto.Text))
            {
                MessageBox.Show("Please select a photo before updating.");
                return;
            }           
            
        }
        #endregion

        #region M�todo Conex�o
        // M�todo respons�vel pela conex�o no banco de dados
        private void Conexao()
        {
            try
            {
                //Criando a inst�ncia da Conex�o
                using (MySqlConnection conexao = new MySqlConnection(stgCon))
                {
                    //Abrindo a conex�o
                    conexao.Open();

                    // Mostra a mensagem para o usu�rio caso exista a conex�o. 
                    MessageBox.Show("Conectado com sucesso! ");
                    
                    // Fecha a conex�o
                    conexao.Close();
                }

            }
            catch(Exception ex)
            {
                // Caso n�o exista a conex�o, a mensagem � mostrada. 
                throw new ArgumentException("Erro ao tentar conectar no banco de dado! " 
                    + ex.Message);
            }


        }
        #endregion
        
        #region CarregarDataGridView
        // M�todo para carregar o DataGridView
        private void CarregarDataGridView()
        {
            // Criando uma nova inst�ncia de conex�o com o banco de dados.
            using (MySqlConnection conexao = new MySqlConnection(stgCon))
            {
                //Abrindo a conex�o
                conexao.Open();

                // Criando nosso consulta no banco e guardando na vari�vel
                string sql = "SELECT * FROM CADASTRO;";

                // Instanciando o MySqlCommand respons�vel
                // por pegar a conex�o com o banco a instru��o SQL                
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    // Mapear as entidades para preencher um Dataset 
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    // Construi os dados em forma de tabela
                    DataTable dt = new DataTable();

                    // Preenche o DataTable
                    da.Fill(dt);

                    // Passa os dados para dentro do DataGridView
                    dataGridView.DataSource = dt;
                }

            }

        }
        #endregion

        #region btnCadastrar
        // Executa o m�todo cadastrar no momento que o bot�o � clicado.
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }
        #endregion

        #region Cadastrar
        // M�todo que faz a persist�ncia dos dados no banco
        private void Cadastrar()
        {
            try
            {
                // Instru��o SQL para inserir os dados vindos do formul�rio
                string query = "INSERT INTO CADASTRO " +
                    "(Id, Nome, Sobrenome, Email, Telefone, Senha, DataNacimento, Foto)" +
                    "VALUES (@Id, @Nome, @Sobrenome, @Email, @Telefone, @Senha, @DataNasc, " +
                    "@Foto);";

                // Novamente criando a conex�o
                using (MySqlConnection con = new MySqlConnection(stgCon))
                {
                    // Abre a conex�o
                    con.Open();
                    // Passando a data do datetimepicker para a query com o par�metro @DataNasc
                    DateTime dataNascim = dataNasc.Value;

                    //Instanciando o MySqlCommand  
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // Adiciona o valores dos campos conforme par�metros 
                        cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.ToString());
                        cmd.Parameters.AddWithValue("@Sobrenome", txtSobrenome.Text.ToString());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                        cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text.ToString());
                        cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.ToString());
                        cmd.Parameters.AddWithValue("@DataNasc", dataNascim);
                        cmd.Parameters.AddWithValue("@Foto", pbFoto.ToString());
                        
                        // Executa a a��o no banco
                        cmd.ExecuteNonQuery();
                    }
                        // Informa o usu�rio
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        
                        // Fecha a conex�o
                        con.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("N�o foi poss�vel realizar o cadastro" + ex.Message);
            };
        }
        #endregion

        #region CadastrarImagem
        // Abre uma janela para selecionar a imagem, que ser� carregada no PictureBox
        private void CarregarImagem()
        {
            // Cria a inst�ncia que permite localizar a imagem no Windows Explorer
            using (OpenFileDialog openImage = new OpenFileDialog())
            {
                // Mostra a imagem caso o usu�rio clique em Ok
                if (openImage.ShowDialog() == DialogResult.OK)
                // Pega o caminho/nome da imagem e passa para o PictureBox
                    pbFoto.Text = openImage.FileName;
                // Passando o objeto para o PictureBox
                pbFoto.Image = Image.FromFile(openImage.FileName);
                // Define o tamanho da imagem 
                pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        #endregion

        #region Atualizar
        // M�todo para atualizar os dados pelo Id
        private void Atualizar()
        {
            // Instru��o SQL
            string query = "UPDATE CADASTRO SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Telefone = @Telefone, Senha = @Senha, DataNacimento = @DataNasc, Foto = @Foto WHERE ID = @ID";
            // Instanciando a conex�o
            using (MySqlConnection con = new MySqlConnection(stgCon))
            {
                // Abre a conex�o
                con.Open();
                // Criando a inst�ncia do MySqlCommand
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    // Passando a data do datetimepicker para a query com o par�metro @DataNasc
                    DateTime dataNascim = dataNasc.Value;
                
                    // Outra forma de chamar o DateTime definindo o formato de sa�da.
                    // DateTime dataNasc = new DateTime(2025, 03, 27);

                    cmd.Parameters.AddWithValue("@ID", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text.ToString());
                    cmd.Parameters.AddWithValue("@Sobrenome", txtSobrenome.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text.ToString());
                    cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.ToString());
                    cmd.Parameters.AddWithValue("@DataNasc", dataNasc);            

                    if (string.IsNullOrEmpty(pbFoto.Text))
                    {
                        throw new ArgumentException("O caminho do arquivo n�o pode ser nulo ou vazio.", nameof(pbFoto.Text));
                    }
                    // Criando um array de imagens e convertendo o conte�do do picturebox para byte
                    byte[] imageBytes = File.ReadAllBytes(pbFoto.Text);                     
                    // Adicionando novo par�metro e imagem convertida
                    cmd.Parameters.AddWithValue("@Foto", imageBytes);
                    // Executa a Query
                    cmd.ExecuteNonQuery();
                    // Fecha a conex�o
                    con.Close();
                }

            }





        }
        #endregion
        
        #region Limpar
        // Limpa o DataGridView
        private void Limpar()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
        }
        #endregion

        #region btnFoto
        // Ao clicar no bot�o chama o m�todo CarregarImagem
        private void btnFoto_Click(object sender, EventArgs e)
        {
            CarregarImagem();
        }
        #endregion

        #region btnAtualizar
        //Executa a atualiza��o do registro conforme ID
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }
        #endregion 
    }
    #endregion
}
#endregion