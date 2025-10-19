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

namespace HelloWorldApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_helloWorld_Click(object sender, RoutedEventArgs e)
        {
            lbl_text.Content = "Hello, World!";
        }

        private void btn_limpar_Click(object sender, RoutedEventArgs e)
        {
            lbl_text.Content = string.Empty;
        }
    }
}