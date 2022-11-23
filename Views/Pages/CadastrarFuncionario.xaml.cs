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
    /// Interação lógica para CadastrarFuncionario.xam
    /// </summary>
    public partial class CadastrarFuncionario : Page
    {
        private Funcionario _func = new Funcionario();
        public CadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCPF.Clear();
            dpData.SelectedDate = null;
            txtNome.Clear();
            txtRG.Clear();
            txtCelular.Clear();
            txtEndereco.Clear();
            txtFuncao.Clear();
            txtSalario.Clear();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _func.CPF = txtCPF.Text;
            _func.DataNasc = Convert.ToString(dpData.SelectedDate.Value);
            _func.Nome = txtNome.Text;
            _func.RG = txtRG.Text;
            _func.Celular = txtCelular.Text;
            _func.Endereco = txtEndereco.Text;
            _func.Funcao = txtFuncao.Text;
            _func.Salario = Convert.ToDouble(txtSalario.Text);
        }
    }
}
