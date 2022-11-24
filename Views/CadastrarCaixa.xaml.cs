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
    /// Lógica interna para CadastrarCaixa.xaml
    /// </summary>
    public partial class CadastrarCaixa : Window
    {
        private Caixa _caixa = new Caixa();
        private Devolucao dev = new Devolucao();
        
        
        public CadastrarCaixa(Devolucao devolucao)
        {
            InitializeComponent();
            Loaded += CadastrarCaixa_Loaded;
            dev = devolucao;
            
        }

        private void CadastrarCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            cbTipPag.DisplayMemberPath = "Texto";
            cbTipPag.SelectedValuePath = "Valor";

            cbTipPag.Items.Add(new { Texto = "A Vista", Valor = 1 });
            cbTipPag.Items.Add(new { Texto = "Prazo", Valor = 2 });
            cbTipPag.Items.Add(new { Texto = "Pix", Valor = 3 });
            cbTipPag.Items.Add(new { Texto = "Cartão", Valor = 4 });
            cbTipPag.Items.Add(new { Texto = "Cheque", Valor = 5 });

            var dao = new DevolucaoDAO();
            
            _caixa.fkFunc = dao.IdFunc(dev);
            _caixa.fkCli = dao.IdCli(dev);
            _caixa.fkDev = dao.IdDev();
            
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _caixa.Data = dev.DataS + " " + dev.DataS;
            _caixa.fkPag = int.Parse(cbTipPag.SelectedValue.ToString());
            _caixa.Valorpag = txtValor.Text;
            
            try
            {
                var dao = new CaixaDAO();
                dao.Insert(_caixa);
                MessageBox.Show("Venda Registrada com sucesso!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
