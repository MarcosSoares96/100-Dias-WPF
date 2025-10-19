using System.Windows;
using System.Windows.Controls;

namespace Day005_Conversor.Janelas
{
    /// <summary>
    /// Interação lógica para ctu_Distancia.xam
    /// </summary>
    public partial class ctu_Distancia : UserControl
    {
        public ctu_Distancia()
        {
            InitializeComponent();
            cbx_PrimeiraUni.ItemsSource = listaDist;
            cbx_SegundaUni.ItemsSource = listaDist;
        }

        double valor = 0;
        string unidade1;
        string unidade2;

        // public readonly List<string> listaDist = ["Milímetro (mm)", "Centímetro (cm)", "Metro (m)", "Quilômetro (km)", "Polegada (in)", "Pé (ft)", "Jarda (yd)", "Milha (mi)"];
        public readonly List<string> listaDist = ["mm", "cm", "m", "km", "in", "ft", "yd", "mi"];

        // Um dicionário aninhado em C# é uma estrutura de dados onde um dicionário contém outro dicionário como valor.
        // Isso é útil para organizar fatores de conversão entre múltiplas unidades de forma hierárquica.
        public Dictionary<string, Dictionary<string, double>> Conversao = new()
        {
            {
                "mm", new Dictionary<string, double>()
                {
                    { "mm", 1 },
                    { "cm", 0.1 },
                    { "m", 0.001 },
                    { "km", 0.000001 },
                    { "in", 0.0393701 },
                    { "ft", 0.00328084 },
                    { "yd", 0.00109361 },
                    { "mi", 0.000000621371 }
                }
            },
            {
                "cm", new Dictionary<string, double>()
                {
                    { "mm", 10 },
                    { "cm", 1 },
                    { "m", 0.01 },
                    { "km", 0.00001 },
                    { "in", 0.393701 },
                    { "ft", 0.0328084 },
                    { "yd", 0.0109361 },
                    { "mi", 0.0000062137 }
                }
            },
            {
                "m", new Dictionary<string, double>()
                {
                    { "mm", 1000 },
                    { "cm", 100 },
                    { "m", 1 },
                    { "km", 0.001 },
                    { "in", 39.3701 },
                    { "ft", 3.28084 },
                    { "yd", 1.09361 },
                    { "mi", 0.000621371 }
                }
            },
            {
                "km", new Dictionary<string, double>()
                {
                    { "mm", 1000000 },
                    { "cm", 100000 },
                    { "m", 1000 },
                    { "km", 1 },
                    { "in", 39370.1 },
                    { "ft", 3280.84 },
                    { "yd", 1093.61 },
                    { "mi", 0.621371 }
                }
            },
            {
                "in", new Dictionary<string, double>()
                {
                    { "in", 1 },
                    { "ft", 0.0833333 },
                    { "yd", 0.0277778 },
                    { "mi", 0.0000157828 },
                    { "mm", 25.4 },
                    { "cm", 2.54 },
                    { "m", 0.0254 },
                    { "km", 0.0000254 }
                }
            },
            {
                "ft", new Dictionary<string, double>()
                {
                    { "in", 12 },
                    { "ft", 1 },
                    { "yd", 0.333333 },
                    { "mi", 0.000189394 },
                    { "mm", 304.8 },
                    { "cm", 30.48 },
                    { "m", 0.3048 },
                    { "km", 0.0003048 }
                }
            },
            {
                "yd", new Dictionary<string, double>()
                {
                    { "in", 36 },
                    { "ft", 3 },
                    { "yd", 1 },
                    { "mi", 0.000568182 },
                    { "mm", 914.4 },
                    { "cm", 91.44 },
                    { "m", 0.9144 },
                    { "km", 0.0009144 }
                }
            },
            {
                "mi", new Dictionary<string, double>()
                {
                    { "in", 63360 },
                    { "ft", 5280 },
                    { "yd", 1760 },
                    { "mi", 1 },
                    { "mm", 1609344 },
                    { "cm", 160934.4 },
                    { "m", 1609.344 },
                    { "km", 1.609344 }
                }
            }
        };

        public void Converter(double valor, string unidade1, string unidade2)
        {
            if (cbx_PrimeiraUni.SelectedItem == null || cbx_SegundaUni.SelectedItem == null)
            {
                MessageBox.Show("Selecione as unidades de medida.");
                return;
            }
            else
            {
                double fatorConvercao = Conversao[unidade1][unidade2];
                double valorConvetido = valor * fatorConvercao;

                tbk_Resultado.Text = valorConvetido.ToString("N4");
            }
        }

        private void tbx_ValorOriginal_TextChanged(object sender, TextChangedEventArgs e)
        {
            valor = Convert.ToDouble(tbx_ValorOriginal.Text);
        }

        private void cbx_SegundaUni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unidade1 = cbx_PrimeiraUni.SelectedValue.ToString();
            unidade2 = cbx_SegundaUni.SelectedValue.ToString();

            Converter(valor, unidade1, unidade2);
        }


        private void cbx_PrimeiraUni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbx_PrimeiraUni.SelectedItem != null && cbx_SegundaUni.SelectedItem != null)
            {
                unidade1 = cbx_PrimeiraUni.SelectedValue.ToString();
                unidade2 = cbx_SegundaUni.SelectedValue.ToString();
                Converter(valor, unidade1, unidade2);
            }
        }
    }
}