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
using System.Windows.Threading;

namespace Day003_RelogioDigital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Um temporizador que é integrado à fila System.Windows.Threading.Dispatcher,
        // a qual é processada em um intervalo de tempo especificado e com uma prioridade especificada.
        private DispatcherTimer timer; // Declara um timer para atualizar a hora

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer(); // Inicializa o timer

            // TimeSpan: Representa um intervalo de tempo
            timer.Interval = TimeSpan.FromSeconds(1); // Define o intervalo para 1 segundo

            // Tick: O evento Tick ocorre quando o intervalo definido pelo DispatcherTimer é atingido.
            timer.Tick += Timer_Tick; // Associa o evento Tick ao método Timer_Tick

            timer.Start(); // Inicia o timer

            AtualizarHora(); // Atualiza a hora imediatamente ao iniciar
        }

        private void Timer_Tick(object sender, EventArgs e) // Método chamado a cada tick do timer
        {
            AtualizarHora(); // Atualiza a hora exibida
        }

        private void AtualizarHora() // Método para atualizar a hora exibida
        {
            lbl_horario.Content = DateTime.Now.ToString("HH:mm:ss"); // Formata a hora atual como HH:mm:ss e atribui ao label
        }

    }
}