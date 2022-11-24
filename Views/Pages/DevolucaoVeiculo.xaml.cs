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
    /// Interação lógica para DevolucaoVeiculo.xam
    /// </summary>
    public partial class DevolucaoVeiculo : Page
    {
        private Devolucao dev = new Devolucao();
        private Carro car = new Carro();
        public DevolucaoVeiculo()
        {
            InitializeComponent();

            CarregarListagem();
        }
        public void CarregarListagem()
        {

            cbCarro.DisplayMemberPath = "Modelo";
            cbCarro.SelectedValuePath = "Value";

            cbRetirada.DisplayMemberPath = "Data";
            cbRetirada.SelectedValuePath = "Value";
            try
            {
                var daocar = new CarroDAO();
                var listacar = daocar.List();
                foreach (var carrinho in listacar)
                {

                    cbCarro.Items.Add(new { Modelo = carrinho.Modelo, Value = carrinho.Id });
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                var dao = new RetiradaDAO();
                var listaret = dao.list();
                foreach (var retiradas in listaret)
                {
                    cbRetirada.Items.Add(new { Data = retiradas.dataHora2, Value = retiradas.Id });
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            dev.FkCar = int.Parse(cbCarro.SelectedValue.ToString());
            dev.FkRetirada = int.Parse(cbRetirada.SelectedValue.ToString());
            dev.Data = LocaleDatePicker.SelectedDate;
            dev.Hora = timePicker.SelectedTime;
            dev.KmRodados = int.Parse(txtKmRodados.Text);


            try
            {
                var dao = new DevolucaoDAO();
                dao.Insert(dev);
                MessageBox.Show("Devolução Realizada!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
