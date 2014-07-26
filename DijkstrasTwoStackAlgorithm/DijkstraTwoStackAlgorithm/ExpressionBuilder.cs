using System.Collections.Generic;
using System.Text;
using DijkstraTwoStackAlgorithm.Helpers;
using DijkstraTwoStackAlgorithm.Interfaces;
using DijkstraTwoStackAlgorithm.Operators;

namespace DijkstraTwoStackAlgorithm
{
    public class ExpressionBuilder : IExpressionBuilder
    {
        //private OperatorBase _lastOperator;
        //private int _lastOperatorPosition;
        //private int _lastNumericPosition;
        private readonly Stack<int> _leftBracePositions;

        private readonly IDefinedOperators _definedOperators;
        private readonly ExpressionBuilderHelper _helper;

        private StringBuilder _expression;

        /// <summary>
        /// Ctor: accepts instance of DefinedOperators
        /// </summary>
        ///// <param name="definedOperators">Instance of DefinedOperators</param>
        public ExpressionBuilder()  //  IDefinedOperators definedOperators)
        {
            //if (definedOperators == null)
            //    throw new ArgumentNullException("definedOperators", "No operators defined to the Expression Builder");

            //_definedOperators = definedOperators;

            _definedOperators = new DefinedOperators();

            _expression = new StringBuilder();

            _helper = new ExpressionBuilderHelper(_definedOperators);

            _leftBracePositions = new Stack<int>();
        }


        //public string Expression
        //{
        //    get { return _expression.ToString(); }
        //    set
        //    {
        //        _expression = new StringBuilder();
        //        _expression.Append(value);
        //    }
        //}



        /// <summary>
        /// Adds a numeric digit to the expression
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        public ExpressionReturnCode AddDigit(char digit)
        {
            if (_helper.IsNumeric(digit))
            {
                //  Is this the first decimal point in the number
                if (!_helper.IsDecimalValid(digit, _expression.ToString()))
                    return new ExpressionReturnCode(false, "A second decimal point is not valid in a number.");
                if (!_helper.IsCommaValid(digit, _expression.ToString()))
                    return new ExpressionReturnCode(false, "Comma not valid after decimal or more than 3 digits separation from previous comma.");
                //  OK
                _expression.Append(digit);
                return new ExpressionReturnCode();
            }

            if (_helper.IsLeadingMinus(digit, _expression.ToString()))
            {
                _expression.Append(digit);
                return  new ExpressionReturnCode();
            }

            return new ExpressionReturnCode(false, string.Format("Invalid digit: '{0} could not be added",digit));
        }

        /// <summary>
        /// Adds an operator to the expression
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public ExpressionReturnCode AddOperator(char c)
        {
            if (_definedOperators.IsOperator(c))
            {
                if (_expression.Length == 0)
                {
                    if (!_helper.IsLeftBrace(c))
                    {
                        return new ExpressionReturnCode(false, "Cannot place operator at beginning of expression");
                    }
                    //  Left brace being added
                    _expression.Append(c);

                    //  Add to position of left braces
                    _leftBracePositions.Push(_expression.Length - 1);

                    return new ExpressionReturnCode();
                }

                //  left brace, previous must be operator
                var idx = _expression.ToString().Length - 1;
                var prevChar = _expression.ToString()[idx];
                if (!_helper.IsNumeric(prevChar) && !_helper.IsRightBrace(prevChar))
                {
                    if (!_helper.IsLeftBrace(c))
                        return new ExpressionReturnCode(false, "Cannot place operater immediately after another operator.");
                }
                //  Add operator to expression
                _expression.Append(c);
                //  if left brace, add to left brace positions
                if (_helper.IsLeftBrace(c))
                    _leftBracePositions.Push(_expression.Length - 1);

                //  Return cusseccful result
                return new ExpressionReturnCode();
            }
            return new ExpressionReturnCode(false, "Invalid Operator, not supported");
        }

        /// <summary>
        /// Adds a RightBrace to the expression
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public ExpressionReturnCode AddRightBrace(char c)
        {
            if (!_helper.IsRightBrace(c))
                return new ExpressionReturnCode(false, "Invalid character: Not a right brace");

            //  Check there are left braces available to be balanced: return Bad if not.
            if (_leftBracePositions.Count == 0)
                return new ExpressionReturnCode(false, "Cannot add right brace, there are no left braces to be balanced");

            //  Check there is an interviening calculation, at least two digits and an operator (something iles between
            var lastLeftBracePosition = _leftBracePositions.Peek();
            if (_expression.Length - lastLeftBracePosition == 1)
                return new ExpressionReturnCode(false, "Cannot add right brace, balanced braces must contain a calculation");

            //  Add right brace to expresion
            _expression.Append(c);

            //  Remove last reference to left brace positions, as balanced
            _leftBracePositions.Pop();

            //  return success
            return new ExpressionReturnCode();
        }


        /// <summary>
        /// Removes the last character fromt the expression.  It can be
        /// either a numeric digit of an operator
        /// </summary>
        public ExpressionReturnCode RemoveLastCharacter()
        {
            if (_expression.Length == 0)
                return new ExpressionReturnCode(false, "No characters available to be removed");

            _expression.Remove(_expression.Length - 1, 1);
            return new ExpressionReturnCode();
        }

        /// <summary>
        /// Clears the content of the expression
        /// </summary>
        public void ClearExpression()
        {
            _expression = new StringBuilder();
            _leftBracePositions.Clear();
        }

        /// <summary>
        /// Returns the Expression as a string
        /// </summary>
        /// <returns>The Expression</returns>
        public string GetExpression()
        {
            return _expression.ToString();
        }

        /// <summary>
        /// Sets the initial value of the expression
        /// </summary>
        /// <param name="expression">The initial expression value</param>
        /// <remarks>
        /// SetExpression is here to facilitate use with a Web based UI.  It
        /// allows the current value of the expression to be set before any
        /// of the methods to add characters to the expression are called.
        /// The HTTP process, is stateless and this builder can then be 
        /// initialised for each HTTP request.
        /// </remarks>
        public void SetExpression(string expression)
        {
            _expression.Clear();
            _expression.Append(expression);
        }

        /// <summary>
        /// Returns string representation of Expression
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _expression.ToString();
        }

    }
}
