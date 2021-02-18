// James Odeyale - Group 1
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator.ViewModel
{

    class TimeCalculatorViewModel : INotifyPropertyChanged
    {
        const double MINUTE_BOUND = 60;
        const double HOUR_BOUND = 3600;
        const double DAY_BOUND = 86400;

        #region Properties
        private String showErrorMessage = "Hidden";
        public String ShowErrorMessage
        {
            get { return showErrorMessage; }
            set { showErrorMessage = value; propertyChanged(); }
        }

        private string errorMessage = "";
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; propertyChanged(); }
        }

        private String displayResult = "Hidden";
        public String DisplayResult
        {
            get { return displayResult; }
            set { displayResult = value; propertyChanged(); }
        }

        private string calculationResult = "";
        public string CalculationResult
        {
            get { return calculationResult; }
            set { calculationResult = value; propertyChanged(); }
        }

        private String userInput = "";
        public String UserInput
        {
            get { return userInput; }
            set { userInput = value; CalculateSeconds(); }
        }

        #endregion

        #region App Display
        private void DisplayErrorOnWrongInput(bool isShow, string message)
        {
            ErrorMessage = message;
            ShowErrorMessage = isShow ? "Visible" : "Hidden";
            CalculationResult = isShow.ToString();
        }

        private void ControlResultDisplay(bool isShow)
        {
            DisplayResult = isShow ? "Visible" : "Hidden"; ;
        }
        #endregion

        #region Validation
        private double ProcessCalculation(double numOfSeconds, double divisionParam)
        {
            return Math.Round(numOfSeconds / divisionParam, 2);
        }

        private double EmptyStringChecker()
        {
            return string.IsNullOrEmpty(UserInput) ? 0 : Double.Parse(UserInput);
        }
        #endregion

        #region Main Function for Calculating Seconds
        public void CalculateSeconds()
        {
            try
            {
                DisplayErrorOnWrongInput(false, "");

                double numOfSeconds = EmptyStringChecker();

                double calcResult;

                if (numOfSeconds >= MINUTE_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, MINUTE_BOUND);
                    CalculationResult = $"You have {calcResult} {(calcResult > 1 ? "minutes" : "minute")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    ControlResultDisplay(true);
                }
                else if (numOfSeconds >= HOUR_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, HOUR_BOUND);
                    CalculationResult = $"You have {calcResult} {(calcResult > 1 ? "hours" : "hour")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    ControlResultDisplay(true);
                }
                else if (numOfSeconds >= DAY_BOUND)
                {
                    calcResult = ProcessCalculation(numOfSeconds, DAY_BOUND);
                    CalculationResult = $"You have {calcResult} {(calcResult > 1 ? "days" : "day")} in {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    ControlResultDisplay(true);
                }
                else
                {
                    CalculationResult = $"You have {numOfSeconds} {(numOfSeconds > 1 ? "seconds" : "second")}";
                    ControlResultDisplay(true);
                }
            }
            catch
            {
                DisplayErrorOnWrongInput(true, "Incorrect number was inputed");
                ControlResultDisplay(false);
            }
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
