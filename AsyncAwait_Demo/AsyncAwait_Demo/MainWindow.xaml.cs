using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait_Demo
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            buttonTask.IsEnabled = false;
            MessageBox.Show("Start");

            await Task.Run(MachEtwasImUI); // Wartet bis der Task fertig ist

            // t1.Wait(); ---> Problem
            MessageBox.Show("Ende");
            buttonTask.IsEnabled = true;
        }

        private void MachEtwasImUI()
        {
            for (int i = 0; i <= 100; i++)
            {
                // Führt diese Zeile Code im UI-Thread aus
                Dispatcher.Invoke(() => progressBarWert.Value = i);
                Thread.Sleep(80);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TEST TEST TEST");
        }
    }
}
