using SQLite;
using System.Data.Common;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string _dbPath; //caminho do banco de dados
        SQLiteConnection conn; // Conexão com o BD SqLite
        

        public MainPage()
        {
            InitializeComponent();
        }

       

        private void CriarBDBtn_Clicked(object sender, EventArgs e)
        {
            // Define o caminho pro BD
            _dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "cadastros.db3");
            //Cria o Banco de Dados

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Cadastro>();
            Operacoes.IsVisible = true;
        }

        private void InserirBtn_Clicked(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Nome = NomeEnt.Text;
            cadastro.Cpf = CpfEnt.Text;
            conn.Insert(cadastro);
            NomeEnt.Text = "";
            IdEnt.Text = "";
            CpfEnt.Text = "";
            LimparCampos();
            ListarCadastros();
        }

        private void AlterarBtn_Clicked(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Id = Convert.ToInt32(IdEnt.Text);
            cadastro.Nome = NomeEnt.Text;
            conn.Update(cadastro);

            LimparCampos();
            ListarCadastros();
        }

        private void ExcluirBtn_Clicked(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(IdEnt.Text);
            conn.Delete<Cadastro>(id);

            LimparCampos();
            ListarCadastros();
        }

        private void LocBtn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ListaBtn_Clicked(object sender, EventArgs e)
        {
            ListarCadastros();
        }

        public void ListarCadastros()
        {
            List<Cadastro> lista
                = conn.Table<Cadastro>().ToList();
            ListaCv.ItemsSource = lista;
        }

        public void LimparCampos()
        {
            IdEnt.Text = "";
            NomeEnt.Text = "";
            CpfEnt.Text = "";
        }
    }
   
}
