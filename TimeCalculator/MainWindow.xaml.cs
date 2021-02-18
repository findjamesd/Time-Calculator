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
        // const double MINUTE_BOUND = 60;
        //const double HOUR_BOUND = 3600;
        // const double DAY_BOUND = 86400;

        TimeCalculatorViewModel tcm = new TimeCalculatorViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = tcm;
            //borderErrorDisplay.Visibility = Visibility.Hidden;
            //spDisplayResult.Visibility = Visibility.Hidden;
            //txtNumOfSeconds.Select(0,0);
        }

       /* private void TxtNumOfSeconds_SelectionChanged(object sender, RoutedEventArgs e)
        {
            tcm.CalculateSeconds();
        }*/


        /*private void DisplayErrorOnWrongInput(bool isShow, string message)
        {
            tbErrorDisplay.Text = message;
            borderErrorDisplay.Visibility = isShow
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void DisplayResult(bool isShow)
        {
            spDisplayResult.Visibility = isShow
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private double ProcessCalculation(double numOfSeconds, double divisionParam)
        {
            return Math.Round(numOfSeconds / divisionParam, 2);
        }
        static double EmptyStringChecker(string currentValue)
        {
            return string.IsNullOrEmpty(currentValue) ? 0 : Double.Parse(currentValue);
        }

        private void TxtNumOfSeconds_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayErrorOnWrongInput(false, "");

                double numOfSeconds = EmptyStringChecker(txtNumOfSeconds.Text);

                double calcResult;

                if (numOfSeconds >= MINUTE_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, MINUTE_BOUND);
                    tbDisplayCalc.Text = $"There are {calcResult} {(calcResult > 1 ? "minutes" : "minute")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    DisplayResult(true);
                }
                else if (numOfSeconds >= HOUR_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, HOUR_BOUND);
                    tbDisplayCalc.Text = $"There are {calcResult} {(calcResult > 1 ? "hours" : "hour")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    DisplayResult(true);
                }
                else if (numOfSeconds >= DAY_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, DAY_BOUND);
                    tbDisplayCalc.Text = $"There are {calcResult} {(calcResult > 1 ? "days" : "day")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    DisplayResult(true);
                }
                else
                {
                    tbDisplayCalc.Text = $"There are {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    DisplayResult(true);
                }
            }
            catch
            {
                DisplayErrorOnWrongInput(true, "Incorrect number was inputed");
                DisplayResult(false);
            }
        }*/
    }
}
