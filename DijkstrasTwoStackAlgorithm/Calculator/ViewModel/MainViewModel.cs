using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DijkstraTwoStackAlgorithm;
using DijkstraTwoStackAlgorithm.Helpers;
using DijkstraTwoStackAlgorithm.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Calculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IAlgorithm _algorithm;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IExpressionBuilder builder, IAlgorithm algorithm)
        {
            //  TODO: Refactor algorithm and expression builder instances to be injected using SimpleIoC.
            if (builder == null)
                throw new ArgumentNullException("builder", "No valid ExpressionBuilder class supplied to ViewModel.");
            if (algorithm == null)
                throw new ArgumentNullException("algorithm", "No valid Algorithm class supplied to ViewModel.");
            _expressionBuilder = builder;
            _algorithm = algorithm;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                this.Expression = "2*(1+2+3)/(1+2)";
                this.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus leo lectus, viverra ut lobortis vel, mollis eget lectus. Suspendisse laoreet consequat ultrices. Curabitur ultricies, tortor feugiat porttitor faucibus, lorem eros pretium nisl, eu ullamcorper mauris tortor sit amet augue.";
            }
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            // bind the handlers to the commands received from the UI
            NineCommand = new RelayCommand(Click9Cmd);
            EightCommand = new RelayCommand(Click8Cmd);
            SevenCommand = new RelayCommand(Click7Cmd);
            SixCommand = new RelayCommand(Click6Cmd);
            FiveCommand = new RelayCommand(Click5Cmd);
            FourCommand = new RelayCommand(Click4Cmd);
            ThreeCommand = new RelayCommand(Click3Cmd);
            TwoCommand = new RelayCommand(Click2Cmd);
            OneCommand = new RelayCommand(Click1Cmd);
            ZeroCommand = new RelayCommand(Click0Cmd);
            DecimalPointCommand = new RelayCommand(ClickDecimalPointCmd);
            CommaCommand = new RelayCommand(ClickCommaCmd);

            AddCommand = new RelayCommand(ClickAddCmd);
            SubtractCommand = new RelayCommand(ClickSubTractCmd);
            MultiplyCommand = new RelayCommand(ClickMultiplyCmd);
            DivideCommand = new RelayCommand(ClickDivideCmd);
            LeftBraceCommand = new RelayCommand(ClickLeftBraceCmd);
            RightBraceCommand = new RelayCommand(ClickRightBraceCmd);

            CancelCommand = new RelayCommand(ClickCancelCmd);
            ClearCommand = new RelayCommand(ClickClearCmd);

            CalculateCommand = new RelayCommand(ClickCalculateCmd);
        }

        /// <summary>
        /// Displays the current expression as it's built up.
        /// </summary>
        private string _expression;
        public string Expression
        {
            get { return _expression; }
            set
            {
                if (value != null && value != _expression)
                {
                    _expression = value;
                    RaisePropertyChanged(() => Expression);
                }
            }
        }

        /// <summary>
        /// Displays any message appropriate 
        /// </summary>
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (value != null && value != _message)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        /*
         * Commands to respond to the command buttons
         * on the calculator
         */
        //  Numbers
        public RelayCommand NineCommand { get; set; }
        public RelayCommand EightCommand { get; set; }
        public RelayCommand SevenCommand { get; set; }
        public RelayCommand SixCommand { get; set; }
        public RelayCommand FiveCommand { get; set; }
        public RelayCommand FourCommand { get; set; }
        public RelayCommand ThreeCommand { get; set; }
        public RelayCommand TwoCommand { get; set; }
        public RelayCommand OneCommand { get; set; }
        public RelayCommand ZeroCommand { get; set; }
        public RelayCommand DecimalPointCommand { get; set; }
        public RelayCommand CommaCommand { get; set; }
        //  Operators
        public RelayCommand AddCommand { get; set; }
        public RelayCommand SubtractCommand { get; set; }
        public RelayCommand MultiplyCommand { get; set; }
        public RelayCommand DivideCommand { get; set; }
        public RelayCommand LeftBraceCommand { get; set; }
        public RelayCommand RightBraceCommand { get; set; }
        //  Reset 
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        //  Execute
        public RelayCommand CalculateCommand { get; set; }

        /*
         * Button Handlers implementations
         * 
         * Number Buttons
         */
        private async void Click9Cmd()
        {
            Message = string.Empty;
            await NumberClicked('9');
        }
        private async void Click8Cmd()
        {
            Message = string.Empty;
            await NumberClicked('8');
        }
        private async void Click7Cmd()
        {
            Message = string.Empty;
            await NumberClicked('7');
        }
        private async void Click6Cmd()
        {
            Message = string.Empty;
            await NumberClicked('6');
        }
        private async void Click5Cmd()
        {
            Message = string.Empty;
            await NumberClicked('5');
        }
        private async void Click4Cmd()
        {
            Message = string.Empty;
            await NumberClicked('4');
        }
        private async void Click3Cmd()
        {
            Message = string.Empty;
            await NumberClicked('3');
        }
        private async void Click2Cmd()
        {
            Message = string.Empty;
            await NumberClicked('2');
        }
        private async void Click1Cmd()
        {
            Message = string.Empty;
            await NumberClicked('1');
        }
        private async void Click0Cmd()
        {
            Message = string.Empty;
            await NumberClicked('0');
        }
        private async void ClickDecimalPointCmd()
        {
            Message = string.Empty;
            await NumberClicked('.');
        }
        private async void ClickCommaCmd()
        {
            Message = string.Empty;
            await NumberClicked(',');
        }

        private async Task NumberClicked(char c)
        {
            var result = await Task.Factory.StartNew(() => _expressionBuilder.AddDigit(c));
            UpdateViewModel(result);
        }

        /*
         * Command Button Handlers
         */
        private async void ClickAddCmd()
        {
            Message = string.Empty;
            await CommandClicked('+');
        }
        private async void ClickSubTractCmd()
        {
            Message = string.Empty;
            await CommandClicked('-');
        }
        private async void ClickMultiplyCmd()
        {
            Message = string.Empty;
            await CommandClicked('*');
        }
        private async void ClickDivideCmd()
        {
            Message = string.Empty;
            await CommandClicked('/');
        }
        private async void ClickLeftBraceCmd()
        {
            Message = string.Empty;
            await CommandClicked('(');
        }
        private async void ClickRightBraceCmd()
        {
            Message = string.Empty;

            var result = await Task.Factory.StartNew(() => _expressionBuilder.AddRightBrace(')'));
            UpdateViewModel(result);
        }


        private async Task CommandClicked(char c)
        {
            var result = await Task.Factory.StartNew(() => _expressionBuilder.AddOperator(c));
            UpdateViewModel(result);
        }


        /*
         * Cancel Error and Clear commands
         */

        private async void ClickCancelCmd()
        {
            Message = string.Empty;
            var result = await Task.Factory.StartNew(() => _expressionBuilder.RemoveLastCharacter());
            UpdateViewModel(result);
        }

        private async void ClickClearCmd()
        {
            Message = string.Empty;
            Expression = string.Empty;
            await Task.Factory.StartNew(() => _expressionBuilder.ClearExpression());
        }

        /*
         * Calculate the value of the expression
         */

        private async void ClickCalculateCmd()
        {
            Message = string.Empty;
            try
            {
                if (Expression == null)
                    _expression = string.Empty; //  avoids raising change event
                var result = await Task.Factory.StartNew(() => _algorithm.Calculate(Expression));
                var displayResult = Expression + " = " + Convert.ToString(result);

                Expression = displayResult;
            }
            catch (Exception)
            {
                Message = "Algorithm encountered an  severe error";
            }

        }



        private void UpdateViewModel(ExpressionReturnCode result)
        {
            if (result.Success)
            {
                this.Expression = _expressionBuilder.GetExpression();
            }
            else
            {
                this.Message = result.ErrorMessage;
            }
        }


    }
}