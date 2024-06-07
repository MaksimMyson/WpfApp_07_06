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

namespace WpfApp_07_06
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int start = Convert.ToInt32(StartTextBox.Text);
            int end = Convert.ToInt32(EndTextBox.Text);
            int threadCount = Convert.ToInt32(ThreadCountTextBox.Text);

            // Створення та запуск потоків
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() => CountNumbers(start, end));
                thread.Start();
            }
        }

        private void CountNumbers(int start, int end)
        {
            // Виведення чисел у вказаному діапазоні
            for (int i = start; i <= end; i++)
            {
                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ResultTextBox.AppendText(i.ToString() + Environment.NewLine);
                });

                Thread.Sleep(200); 
            }
        }
    }
}