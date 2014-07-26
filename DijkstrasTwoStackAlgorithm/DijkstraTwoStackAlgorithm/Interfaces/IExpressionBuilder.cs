using DijkstraTwoStackAlgorithm.Helpers;

namespace DijkstraTwoStackAlgorithm.Interfaces
{
    public interface IExpressionBuilder
    {
        /// <summary>
        /// Adds a numeric digit to the expression
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        ExpressionReturnCode AddDigit(char digit);

        /// <summary>
        /// Adds an operator to the expression
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        ExpressionReturnCode AddOperator(char c);

        /// <summary>
        /// Adds a right brace to the expression if these is 
        /// a left brace to balance
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        ExpressionReturnCode AddRightBrace(char c);
        
        /// <summary>
        /// Removes the last character fromt the expression.  It can be
        /// either a numeric digit of an operator
        /// </summary>
        ExpressionReturnCode RemoveLastCharacter();

        /// <summary>
        /// Clears the content of the expression
        /// </summary>
        void ClearExpression();

        /// <summary>
        /// Returns the Expression as a string
        /// </summary>
        /// <returns>The Expression</returns>
        string GetExpression();

        /// <summary>
        /// Sets the initial value of the expression
        /// </summary>
        /// <param name="expression">The initial expression value</param>
        void SetExpression(string expression);

    }
}
