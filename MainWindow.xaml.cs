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
using MaterialDesignThemes.Wpf;
using sislocacao.Views.Pages;
using sislocacao.Views;

namespace sislocacao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemCliente_Click(object sender, RoutedEventArgs e)
        {
            Paginas.Content = new CadastrarCliente();
        }
        private void MenuItemListarCliente_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ListClient();
            tela.ShowDialog();
        }


        private void MenuItemCarro_Click(object sender, RoutedEventArgs e)
        {
            Paginas.Content = new CadastrarCarro();
        }

        private void MenuItemListarCarro_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ListCarro();
            tela.ShowDialog();
        }

        private void MenuItemFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Paginas.Content = new CadastrarFuncionario();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Paginas.Content = new RetiradaVeiculos();
        }

        private void ButtonDevolucao_Click(object sender, RoutedEventArgs e)
        {
            Paginas.Content = new DevolucaoVeiculo();
        }

        private void ButtonListAgenda_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ListCaixa();
            tela.ShowDialog();

        }
    }
}
