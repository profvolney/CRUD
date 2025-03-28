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
        // Criando a variável que pega a conexão com o banco de dados.
        string stgCon = "Server=127.0.0.1;Port=3306;Database=Crud;uid=root;Pwd=;";
        #endregion

        #region Construtor
        // Construtor
        public CRUD()
        {
            // Método para inicializar o Formulário
            InitializeComponent();
            // Método para limpar o DataGridView
            Limpar();
            // Atualiza o DataGridView
            dataGridView.Refresh();
            // Carrega o DataGridView
            CarregarDataGridView();
        }
        #endregion
        
        #region Load
        // Método Load que serve para carregamento de métodos quando a aplicação é carregada
        private void CRUD_Load(object sender, EventArgs e)
        {
            // Carrega o método faz conexão no banco de dados.
            Conexao();

            // Se não a foto não for selecionada informa o usuário
            // que precisa fazer o upload da foto primeiro.
            if (string.IsNullOrEmpty(pbFoto.Text))
            {
                MessageBox.Show("Please select a photo before updating.");
                return;
            }           
            
        }
        #endregion

        #region Método Conexão
        // Método responsável pela conexão no banco de dados
        private void Conexao()
        {
            try
            {
                //Criando a instância da Conexão
                using (MySqlConnection conexao = new MySqlConnection(stgCon))
                {
                    //Abrindo a conexão
                    conexao.Open();

                    // Mostra a mensagem para o usuário caso exista a conexão. 
                    MessageBox.Show("Conectado com sucesso! ");
                    
                    // Fecha a conexão
                    conexao.Close();
                }

            }
            catch(Exception ex)
            {
                // Caso não exista a conexão, a mensagem é mostrada. 
                throw new ArgumentException("Erro ao tentar conectar no banco de dado! " 
                    + ex.Message);
            }


        }
        #endregion
        
        #region CarregarDataGridView
        // Método para carregar o DataGridView
        private void CarregarDataGridView()
        {
            // Criando uma nova instância de conexão com o banco de dados.
            using (MySqlConnection conexao = new MySqlConnection(stgCon))
            {
                //Abrindo a conexão
                conexao.Open();

                // Criando nosso consulta no banco e guardando na variável
                string sql = "SELECT * FROM CADASTRO;";

                // Instanciando o MySqlCommand responsável
                // por pegar a conexão com o banco a instrução SQL                
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
        // Executa o método cadastrar no momento que o botão é clicado.
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }
        #endregion

        #region Cadastrar
        // Método que faz a persistência dos dados no banco
        private void Cadastrar()
        {
            try
            {
                // Instrução SQL para inserir os dados vindos do formulário
                string query = "INSERT INTO CADASTRO " +
                    "(Id, Nome, Sobrenome, Email, Telefone, Senha, DataNacimento, Foto)" +
                    "VALUES (@Id, @Nome, @Sobrenome, @Email, @Telefone, @Senha, @DataNasc, " +
                    "@Foto);";

                // Novamente criando a conexão
                using (MySqlConnection con = new MySqlConnection(stgCon))
                {
                    // Abre a conexão
                    con.Open();
                    // Passando a data do datetimepicker para a query com o parâmetro @DataNasc
                    DateTime dataNascim = dataNasc.Value;

                    //Instanciando o MySqlCommand  
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // Adiciona o valores dos campos conforme parâmetros 
                        cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.ToString());
                        cmd.Parameters.AddWithValue("@Sobrenome", txtSobrenome.Text.ToString());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                        cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text.ToString());
                        cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.ToString());
                        cmd.Parameters.AddWithValue("@DataNasc", dataNascim);
                        cmd.Parameters.AddWithValue("@Foto", pbFoto.ToString());
                        
                        // Executa a ação no banco
                        cmd.ExecuteNonQuery();
                    }
                        // Informa o usuário
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        
                        // Fecha a conexão
                        con.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Não foi possível realizar o cadastro" + ex.Message);
            };
        }
        #endregion

        #region CadastrarImagem
        // Abre uma janela para selecionar a imagem, que será carregada no PictureBox
        private void CarregarImagem()
        {
            // Cria a instância que permite localizar a imagem no Windows Explorer
            using (OpenFileDialog openImage = new OpenFileDialog())
            {
                // Mostra a imagem caso o usuário clique em Ok
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
        // Método para atualizar os dados pelo Id
        private void Atualizar()
        {
            // Instrução SQL
            string query = "UPDATE CADASTRO SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Telefone = @Telefone, Senha = @Senha, DataNacimento = @DataNasc, Foto = @Foto WHERE ID = @ID";
            // Instanciando a conexão
            using (MySqlConnection con = new MySqlConnection(stgCon))
            {
                // Abre a conexão
                con.Open();
                // Criando a instância do MySqlCommand
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    // Passando a data do datetimepicker para a query com o parâmetro @DataNasc
                    DateTime dataNascim = dataNasc.Value;
                
                    // Outra forma de chamar o DateTime definindo o formato de saída.
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
                        throw new ArgumentException("O caminho do arquivo não pode ser nulo ou vazio.", nameof(pbFoto.Text));
                    }
                    // Criando um array de imagens e convertendo o conteúdo do picturebox para byte
                    byte[] imageBytes = File.ReadAllBytes(pbFoto.Text);                     
                    // Adicionando novo parâmetro e imagem convertida
                    cmd.Parameters.AddWithValue("@Foto", imageBytes);
                    // Executa a Query
                    cmd.ExecuteNonQuery();
                    // Fecha a conexão
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
        // Ao clicar no botão chama o método CarregarImagem
        private void btnFoto_Click(object sender, EventArgs e)
        {
            CarregarImagem();
        }
        #endregion

        #region btnAtualizar
        //Executa a atualização do registro conforme ID
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }
        #endregion 
    }
    #endregion
}
#endregion