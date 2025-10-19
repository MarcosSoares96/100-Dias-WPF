using System.Windows;

namespace Day002_ContadorDeCliques
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbl_mostradorCliques.Content = string.Empty;
        }


        private void btn_clique_Click(object sender, RoutedEventArgs e)
        {
            if (lbl_mostradorCliques.Content.ToString() == string.Empty)
            {
                lbl_mostradorCliques.Content = "1";
            }
            else
            {
                int contador = int.Parse(lbl_mostradorCliques.Content.ToString());
                contador++;
                lbl_mostradorCliques.Content = contador.ToString();
            }
        }

    }
}