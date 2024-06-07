using System.IO;
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
        private int[] numbers = new int[10000];
        private int minValue, maxValue;
        private double averageValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateNumbers();

            Thread minThread = new Thread(FindMin);
            Thread maxThread = new Thread(FindMax);
            Thread avgThread = new Thread(FindAverage);
            Thread printThread = new Thread(PrintToFile);

            minThread.Start();
            maxThread.Start();
            avgThread.Start();
            printThread.Start();

            minThread.Join();
            maxThread.Join();
            avgThread.Join();
            printThread.Join();

            MessageBox.Show("Всі обчислення завершено.");
        }

        private void GenerateNumbers()
        {
            Random rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1000); // Генеруємо випадкове число від 0 до 999
            }
        }

        private void FindMin()
        {
            minValue = numbers.Min();
        }

        private void FindMax()
        {
            maxValue = numbers.Max();
        }

        private void FindAverage()
        {
            averageValue = numbers.Average();
        }

        private void PrintToFile()
        {
            using (StreamWriter writer = new StreamWriter("results.txt"))
            {
                writer.WriteLine($"Мінімум: {minValue}");
                writer.WriteLine($"Максимум: {maxValue}");
                writer.WriteLine($"Середнє: {averageValue}");
                writer.WriteLine("Набір чисел:");

                foreach (int num in numbers)
                {
                    writer.WriteLine(num);
                }
            }
        }
    }
}