// James Odeyale - Group 1
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator.ViewModel
{

    class TimeCalculatorViewModel : INotifyPropertyChanged
    {
        const int SECONDS_IN_A_MINUTE = 60;
        const int SECONDS_IN_AN_HOUR = 3600;
        const int SECONDS_IN_A_DAY = 86400;

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

        private String borderControl = "#44AF69";
        public String BorderControl
        {
            get { return borderControl; }
            set { borderControl = value; propertyChanged(); }
        }

        private string secondsCalc = "";
        public string SecondsCalc
        {
            get { return secondsCalc; }
            set { secondsCalc = value; propertyChanged(); }
        }

        private string minuteCalc = "";
        public string MinuteCalc
        {
            get { return minuteCalc; }
            set { minuteCalc = value; propertyChanged(); }
        }

        private string hoursCalc = "";
        public string HoursCalc
        {
            get { return hoursCalc; }
            set { hoursCalc = value; propertyChanged(); }
        }

        private string daysCalc = "";
        public string DaysCalc
        {
            get { return daysCalc; }
            set { daysCalc = value; propertyChanged(); }
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
            BorderControl = isShow ? "#B1060F" : "#44AF69";
            ControlResultDisplay(false);
        }

        private void ControlResultDisplay(bool isShow)
        {
            DisplayResult = isShow ? "Visible" : "Hidden";
        }
        #endregion

        #region Validation
        private long EmptyStringChecker()
        {
            return string.IsNullOrEmpty(UserInput) ? 0 : Int64.Parse(UserInput);
        }
        #endregion

        #region Processing Calc function
        private void ProcessCalculation(long seconds)
        {
            if (seconds >= SECONDS_IN_A_DAY)
            {
                DaysCalc = $"{seconds / SECONDS_IN_A_DAY} {(seconds / SECONDS_IN_A_DAY > 1 ? " Days" : " Day")}";
                seconds %= SECONDS_IN_A_DAY;
            }
            else
            {
                DaysCalc = "0 Day";
            }

            if (seconds >= SECONDS_IN_AN_HOUR)
            {
                HoursCalc = $"{seconds / SECONDS_IN_AN_HOUR} {(seconds / SECONDS_IN_AN_HOUR > 1 ? " Hours" : " Hour")}";
                seconds %= SECONDS_IN_AN_HOUR;
            }
            else
            {
                HoursCalc = "0 Hour";
            }

            if (seconds >= SECONDS_IN_A_MINUTE)
            {
                MinuteCalc = $"{seconds / SECONDS_IN_A_MINUTE} {(seconds / SECONDS_IN_A_MINUTE > 1 ? " Minutes" : " Minute")}";
                seconds %= SECONDS_IN_A_MINUTE;
            }
            else
            {
                MinuteCalc = "0 Minute";
            }

            SecondsCalc = $"{seconds} {(seconds > 1 ? " Seconds" : " Second")}";
        }
        #endregion

        #region Main Function for Calculating Seconds
        public void CalculateSeconds()
        {
            try
            {
                DisplayErrorOnWrongInput(false, "");

                long numOfSeconds = EmptyStringChecker();

                long seconds = numOfSeconds;

                ProcessCalculation(seconds);

                ControlResultDisplay(true);
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

