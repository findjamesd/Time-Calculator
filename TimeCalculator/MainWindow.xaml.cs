// James Odeyale - Group 1
using System.Windows;
using TimeCalculator.ViewModel;

namespace TimeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeCalculatorViewModel timeCalculatorViewModel = new TimeCalculatorViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = timeCalculatorViewModel;
        }
    }
}
