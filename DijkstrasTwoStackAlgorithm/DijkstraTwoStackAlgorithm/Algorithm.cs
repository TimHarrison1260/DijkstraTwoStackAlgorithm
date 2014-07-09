using System.Collections.Generic;
using DijkstraTwoStackAlgorithm.Operators;

namespace DijkstraTwoStackAlgorithm
{
    /// <summary>
    /// Implements Dijkstra's Two Stack Algorithm for parsing
    /// mathematical expressions and computing the result
    /// </summary>
    /// <remarks>
    /// Assumptions:
    /// 1.  It currently only supports Addition, subraction, multiplication and division
    ///     and accepts the use of braces '()' to determine the precedence of operations
    /// 2.  The expression must be well formed with balanced brackets, there is no 
    ///     validation to check for this.
    /// 3.  The operators observe normal precedence, i.e. Mult/Div before Add/Sub
    /// 4.  The operators are tokenised as the corresponding ASCII code
    /// </remarks>
    public class Algorithm
    {
        private readonly Stack<double> _values;
        private readonly Stack<OperatorBase> _operators;
        private readonly DefinedOperators _definedOperators;

        public Algorithm()
        {
            //  Stacks for the algorithm
            _values = new Stack<double>();
            _operators = new Stack<OperatorBase>();

            //  Operators defined for the algorithm
            _definedOperators = new DefinedOperators();        
        }

        /// <summary>
        /// Dijkstra's Two-Stack Algorithm for interpreting
        /// mathematical expressions, written as strings.
        /// </summary>
        /// <param name="expression">The string representation of the mathematical expression</param>
        /// <returns>Result of the expression</returns>
        /// <remarks>
        /// Value:  Push onto the Values stack
        /// Operator:   Push onto the Operator stack, unless top of stack is a higher precedence operator, in which
        ///             case, calculate that new value first and place it on the values stack then push the operator
        ///             onto the stack
        /// Left (:     Add to the Operator stack, to delimite precedence.
        /// Right ):    pop two values and the operator from the stacks, calculate the result.  continue like this
        ///             until a leftBrace operator is encountered, removing the leftBrace operator.
        /// </remarks>
        public double Interpret(string expression)
        {
            foreach (var s in expression)
            {
                if (IsIgnore(s)) continue;      //  Ignore character (space)

                if (IsValue(s))
                {
                    _values.Push((double)(s - 48));
                    continue;
                }

                if (IsLeftBrace(s))
                {
                    //  push the Bracket OP to the operator stack: a special operator
                    _operators.Push(_definedOperators.GetOperator(s));
                    continue;
                }

                if (_definedOperators.IsOperator(s))
                {
                    var op = _definedOperators.GetOperator(s);

                    if (_operators.Count > 0)
                    {
                        //  If the operator stack is not empty
                        //  AND top operator is not "("
                        //  AND top operator.precedence > thisOp.precedence
                        //  Then:
                        //      Pop the operator and two values, Right value then left value
                        //      Calculate new value
                        //      Push the new value to the values stack
                        //  Push the operator onto the operator stack

                        //  Get top operator
                        var topOp = _operators.Peek();
                        while
                            (_operators.Count > 0 &&                        //  Stack not empty
                            (topOp.GetType() != typeof(OpLeftBrace)) &&    //  Not Left Brace
                            topOp.Precedence > op.Precedence)               //  Higher precedence
                        {
                            _values.Push(ComputeIntermediateResult());
                            if (_operators.Count > 0)
                                topOp = _operators.Peek();
                        }
                    }

                    _operators.Push(op);
                    
                    continue;
                }

                if (IsRightBrace(s))
                {
                    //  while the operator is not a LeftBrace
                    //  Then;
                    //      pop the op, two values and calculate
                    //      Push the new value to the values stack
                    //  pop the left brace off the operators stack
                    var topOp = _operators.Peek();

                    while (topOp.GetType() != typeof (OpLeftBrace)) //  Not left Brace
                    {
                        _values.Push(ComputeIntermediateResult());
                        topOp = _operators.Peek();
                    }
                    //  Remove the top LeftBrace operator
                    _operators.Pop();
                }

            }

            //  Calculate all remaining operators left at end of expression
            while(_operators.Count > 0)
            {
                _values.Push(ComputeIntermediateResult());
            }

            if (_values.Count > 0)
                return _values.Pop();
            return 0D;
        }

        /// <summary>
        /// Determine if character is a left bracket
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a left bracket otherwise false</returns>
        private bool IsLeftBrace(char c)
        {
            //var remainder = 40 - c; //  (
            if ((40 - c) == 0) return true;
            return false;
        }

        /// <summary>
        /// Determines if the character is to be ignored
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if space otherwise false</returns>
        private bool IsIgnore(char c)
        {
            //remainder = 32 - c;     //  ' ' space
            if ((32 - c) == 0) return true;
            return false;
        }

        /// <summary>
        /// Determines of the character is a number
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a number otherwise false</returns>
        private bool IsValue(char c)
        {
            //  To be a value it must be 0, 9 inclusive => 48, 57
            var result = (c < 58 && c > 47);
            return result;
        }

        /// <summary>
        /// Determines if character is a Right bracket
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a right bracket otherwise false</returns>
        private bool IsRightBrace(char c)
        {
            //var remainder = 41 - c;
            if ((41 - c) == 0) return true;
            return false;
        }

        /// <summary>
        /// Computes the intermediate results using the operator
        /// and values poped from the two stacks
        /// </summary>
        /// <returns>Computed value</returns>
        private double ComputeIntermediateResult()
        {
            //  Get values
            var vRight = _values.Pop();
            var vLeft = _values.Pop();
            var op = _operators.Pop();

            //  TODO: Refactor to add the left and right values as properties and then just call calculate.

            var result = op.Calculate(vLeft, vRight);
            return result;
        }
    }
}
