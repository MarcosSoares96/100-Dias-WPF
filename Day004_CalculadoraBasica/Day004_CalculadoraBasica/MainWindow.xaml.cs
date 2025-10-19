using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day004_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numA, numB;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_mais_Click(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos())
            {
                Operacao('+');
            }
        }

        public bool VerificaCampos()
        {
            if (string.IsNullOrWhiteSpace(tbx_numA.Text) || string.IsNullOrWhiteSpace(tbx_numB.Text))
            {
                lbl_resultado.Foreground = Brushes.Red;
                lbl_resultado.Content = "Preencha os dois campos!";

                return false;
            }
            return true;
        }

        private void tbx_numB_TextChanged(object sender, TextChangedEventArgs e)
        {
            numB = int.Parse(tbx_numB.Text);
        }

        private void tbx_numA_TextChanged(object sender, TextChangedEventArgs e)
        {
            numA = int.Parse(tbx_numA.Text);
        }

        private void btn_menos_Click(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos())
            {
                Operacao('-');
            }
        }

        private void btn_divisao_Click(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos())
            {
                Operacao('/');
            }
        }

        private void btn_mult_Click(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos())
            {
                Operacao('*');
            }
        }

        public void Operacao(char operacao)
        {
            switch (operacao)
            {
                case '+':
                    lbl_resultado.Content = numA + numB;
                    break;
                case '-':
                    lbl_resultado.Content = numA - numB;
                    break;
                case '*':
                    lbl_resultado.Content = numA * numB;
                    break;
                case '/':
                    lbl_resultado.Content = numA / numB;
                    break;
                default:
                    break;
            }
        }
    }
}