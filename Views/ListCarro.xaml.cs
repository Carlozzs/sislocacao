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
using System.Windows.Shapes;
using sislocacao.Views.Pages;

namespace sislocacao.Views
{
    /// <summary>
    /// Lógica interna para ListCarro.xaml
    /// </summary>
    public partial class ListCarro : Window
    {
        public ListCarro()
        {
            InitializeComponent();
            Loaded += ListCarro_Loaded;
        }

        private void ListCarro_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new CarroDAO();
                List<Carro> carros = dao.ListAll();
                dataGridCarro.ItemsSource = carros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridCarro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new CarroDAO();
                List<Carro> carros = dao.ListAll();
                dataGridCarro.ItemsSource = carros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var carroSelect = dataGridCarro.SelectedItem as Carro;

            var resultado = MessageBox.Show($"Deseja realmente atualizar o registro '{carroSelect.Modelo}' ?", "Confirmação de alteração",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                var form = new UpdateCarro(carroSelect);
                form.ShowDialog();
                CarregarListagem();
            }

            CarregarListagem();
        }
    }
}
