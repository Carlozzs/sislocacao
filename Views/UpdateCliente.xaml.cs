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
using System.Windows.Shapes;
using sislocacao.Models;

namespace sislocacao.Views
{
    /// <summary>
    /// Lógica interna para UpdateCliente.xaml
    /// </summary>
    public partial class UpdateCliente : Window
    {
        private Cliente _cli = new Cliente();
        public UpdateCliente(Cliente cliente)
        {
            InitializeComponent();
            _cli = cliente;
            Loaded += UpdateCliente_Loaded;
        }

        private void UpdateCliente_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cli.Nome;
            txtCPF.Text = _cli.CPF;
            txtRG.Text = _cli.RG;
            dpData.Text = _cli.DataNascimento.ToString();
            cbEstadoCivil.Text = _cli.EstadoCivil;
            txtTelefone.Text = _cli.Telefone;
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            _cli.Nome = txtNome.Text;
            _cli.CPF = txtCPF.Text;
            _cli.RG = txtRG.Text;
            _cli.DataNascimento = dpData.SelectedDate.Value;
            _cli.EstadoCivil = cbEstadoCivil.Text;
            _cli.Telefone = txtTelefone.Text;

            var dao = new ClienteDAO();
            try
            {

                dao.Update(_cli);

                MessageBox.Show("Registro de carro atualizado com sucesso.");

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
