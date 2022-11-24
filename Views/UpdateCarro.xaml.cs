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
    /// Lógica interna para UpdateCarro.xaml
    /// </summary>
    public partial class UpdateCarro : Window
    {

        private Carro _carro = new Carro();
        public UpdateCarro(Carro carro)
        {
            InitializeComponent();
            Loaded += UpdateCarro_Loaded;
            _carro = carro;
        }

        private void UpdateCarro_Loaded(object sender, RoutedEventArgs e)
        {
            txtCor.Text = _carro.Cor;
            txtMarca.Text = _carro.Marca;
            txtModelo.Text = _carro.Modelo;
            txtPlaca.Text = _carro.Placa;
            txtPortas.Text = _carro.Porta;
        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            _carro.Cor = txtCor.Text;
            _carro.Marca = txtMarca.Text;
            _carro.Modelo = txtModelo.Text;
            _carro.Placa = txtPlaca.Text;
            _carro.Porta = txtPortas.Text;

            var dao = new CarroDAO  ();
            try
            {

                dao.Update(_carro);

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
