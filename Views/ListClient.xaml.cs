using sislocacao.Models;
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

namespace sislocacao.Views
{
    /// <summary>
    /// Interação lógica para ListClient.xam
    /// </summary>
    public partial class ListClient : Window
    {
        public ListClient()
        {
            InitializeComponent();
            Loaded += ListClient_Loaded;
        }

        private void ListClient_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> carros = dao.List();
                dataGridCarro.ItemsSource = carros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> carros = dao.List();
                dataGridCarro.ItemsSource = carros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var carroSelect = dataGridCarro.SelectedItem as Cliente;

            var resultado = MessageBox.Show($"Deseja realmente atualizar o registro '{carroSelect.Nome}' ?", "Confirmação de alteração",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                var form = new UpdateCliente(carroSelect);
                form.ShowDialog();
                CarregarListagem();
            }

            CarregarListagem();
        }
    }
}
