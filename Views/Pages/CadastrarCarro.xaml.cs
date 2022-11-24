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
    /// Interação lógica para CadastrarCarro.xam
    /// </summary>
    public partial class CadastrarCarro : Page
    {
        private Carro car = new Carro();
        public CadastrarCarro()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            car.Placa = txtPlaca.Text;
            car.Porta = txtPortas.Text;
            car.Status = "disponivel";
            car.Marca = txtMarca.Text;
            car.Modelo = txtModelo.Text;
            car.Cor = txtCor.Text;

            try
            {
                var dao = new CarroDAO();
                dao.Insert(car);
                MessageBox.Show("Carro cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCor.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlaca.Clear();
            txtPortas.Clear();
        }
    }
}
