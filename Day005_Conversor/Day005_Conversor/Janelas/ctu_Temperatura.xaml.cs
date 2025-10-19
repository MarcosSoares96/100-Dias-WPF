using System.Windows.Controls;

namespace Day005_Conversor.Janelas
{
    /// <summary>
    /// Interação lógica para ctu_Temperatura.xam
    /// </summary>
    public partial class ctu_Temperatura : UserControl
    {
        public ctu_Temperatura()
        {
            InitializeComponent();
            cbx_PrimeiraUni.ItemsSource = listaTemperatura;
            cbx_SegundaUni.ItemsSource = listaTemperatura;
        }


        double valor = 0;
        string primeiraUnidade;
        string segundaUnidade;

        public readonly List<string> listaTemperatura = ["°C", "°F", "K"];

    }
}
