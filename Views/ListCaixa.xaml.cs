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

namespace sislocacao.Views
{
    /// <summary>
    /// Interação lógica para ListCaixa.xam
    /// </summary>
    public partial class ListCaixa : Window
    {
        public ListCaixa()
        {
            InitializeComponent();
            Loaded += ListCaixa_Loaded;
        }

        private void ListCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new CaixaDAO();
                List<Caixa> caixas = dao.List();

                dataGridCaixa.ItemsSource = caixas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
