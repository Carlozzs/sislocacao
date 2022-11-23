using MaterialDesignThemes.Wpf;
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

namespace sislocacao.Views.Pages
{
    /// <summary>
    /// Interação lógica para RetiradaVeiculos.xam
    /// </summary>
    public partial class RetiradaVeiculos : Page
    {
        private Carro _carro = new Carro();
        private Retirada _retirada = new Retirada();
        public RetiradaVeiculos()
        {
            InitializeComponent();
            Loaded += RetiradaVeiculos_Loaded;
        }

        private void RetiradaVeiculos_Loaded(object sender, RoutedEventArgs e)
        {
            var dao = new CarroDAO();
            var listaCarro = dao.List();

            var dao2 = new FuncionarioDAO();
            var listaFuncionario = dao2.List();

            var dao3 = new ClienteDAO();
            var listaCliente = dao3.List();

            foreach(var carro in listaCarro)
            {
                cbCarro.Items.Add(carro.Modelo);
            }

            foreach (var funcionario in listaFuncionario)
            {
                cbFuncionario.Items.Add(funcionario.Nome);
            }

            foreach (var cliente in listaCliente)
            {
                cbCliente.Items.Add(cliente.Nome);
            }
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            var dao = new CarroDAO();
            var dao2 = new FuncionarioDAO();
            var dao3 = new ClienteDAO();
            var dao4 = new RetiradaDAO();



            _retirada.dataHora2 = LocaleDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + TimePicker.Text;
            _retirada.id_func_fk = dao2.PegarId(cbFuncionario.SelectedItem.ToString());
            _retirada.id_car_fk = dao.PegarId(cbCarro.SelectedItem.ToString());
            _retirada.id_cli_fk = dao3.PegarId(cbCliente.SelectedItem.ToString());

            try
            {
                dao4.Insert(_retirada);
                MessageBox.Show("Retirada de veículo registrado com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
