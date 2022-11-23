using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sislocacao.Models;

namespace sislocacao.Views.Pages
{
    /// <summary>
    /// Interação lógica para CadastrarCliente.xam
    /// </summary>
    public partial class CadastrarCliente : Page
    {
        private Cliente _cli = new Cliente();
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {

            _cli.Nome = txtNome.Text;
            _cli.RG = txtRG.Text;
            _cli.Telefone = txtTelefone.Text;
            _cli.EstadoCivil = cbEstadoCivil.Text;
            _cli.DataNascimento = dpData.SelectedDate.Value;
            _cli.CPF = txtCPF.Text;

            var dao = new ClienteDAO();

            try
            {
                dao.Insert(_cli);
                MessageBox.Show("Cliente registrado com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
