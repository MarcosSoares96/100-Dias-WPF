using Day005_Conversor.Janelas;
using System.Windows;

namespace Day005_Conversor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new ctu_TelaInicial();
        }

        // Botões de navegação
        private void btn_distancia_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ctu_Distancia();
        }

        private void btn_temper_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ctu_Temperatura();
        }

        private void btn_peso_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ctu_Peso();
        }

        private void btn_tempo_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ctu_Tempo();
        }
    }
}