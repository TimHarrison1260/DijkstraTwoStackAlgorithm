using System;
using DijkstraTwoStackAlgorithm.Operators;

namespace DijkstraTwoStackAlgorithm.Helpers
{
    /// <summary>
    /// Class ExpressionHelper provides methods for interpreting
    /// the expression contents.
    /// </summary>
    public class AlgorithmHelper
    {
        private readonly DefinedOperators _definedOperators;

        public AlgorithmHelper()
        {
            _definedOperators = new DefinedOperators();
        }


        /// <summary>
        /// Determines if the character is to be ignored
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if space otherwise false</returns>
        protected internal bool IsIgnore(char c)
        {
            //  Space
            return (c == 32) ;
        }

        /// <summary>
        /// Determines of the character is a number
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a number otherwise false</returns>
        protected internal bool IsNumeric(char c)
        {
            //  To be a value it must be 0, 9 inclusive => 48, 57
            //  Add . and , => 44, 46
            var result = (c < 58 && c > 47) || (c == 44) || (c == 46);
            return result;
        }

        /// <summary>
        /// Determines if the character is a leading minus sign
        /// </summary>
        /// <param name="c">the current character</param>
        /// <param name="expression">Expression being evaluated</param>
        /// <param name="currentPosition">Current postion within the expression</param>
        /// <returns>True if leading minus otherwise false</returns>
        protected internal bool IsLeadingMinus(char c, string expression, int currentPosition)
        {
            if (c != 45) return false;                  // Not minus sign

            //  At the end of the string?
            if (currentPosition + 1 == expression.Length) return false;

            var nextChar = expression[currentPosition + 1];
            //  1st char in expression and next is numeric, then leading minus
            if (currentPosition == 0 && IsNumeric(nextChar)) return true;

            var previousChar = expression[currentPosition - 1];
            //  Not 1st char then the previous must be Operator or (, and next must be numeric
            var result = (_definedOperators.IsOperator(previousChar) || IsLeftBrace(previousChar)) && IsNumeric(nextChar);

            //  Otherwise it's not a leading minus            
            return result;
        }

        /// <summary>
        /// Gets the length of the value within the expression
        /// </summary>
        /// <param name="expression">Expression containing the value</param>
        /// <param name="startPosition">First positon of value</param>
        /// <returns>Length of the value within the expression</returns>
        protected internal int GetValueLength(string expression, int startPosition)
        {
            var i = startPosition;
            char c = ' ';
            //  Already know first position is numeric, skip it.
            do
            {
                i++;
                if (i < expression.Length)
                    c = expression[i];
            } while (i < expression.Length && IsNumeric(c));

            var len = i - startPosition;
            return len;
        }

        /// <summary>
        /// Convert the string value to double
        /// </summary>
        /// <param name="expression">Expresion containing the value</param>
        /// <param name="startPosition">start position</param>
        /// <param name="length">length</param>
        /// <returns>value</returns>
        /// <remarks>
        /// Assumption: The section of the string contains only value numeric characters
        /// </remarks>
        protected internal double GetValue(string expression , int startPosition, int length)
        {
            var strValue = expression.Substring(startPosition, length);
            var result = Convert.ToDouble(strValue);
            return result;
        }

        /// <summary>
        /// Determine if character is a left bracket
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a left bracket otherwise false</returns>
        protected internal bool IsLeftBrace(char c)
        {
            return (c == 40);
        }

        /// <summary>
        /// Determines if character is a Right bracket
        /// </summary>
        /// <param name="c">the character</param>
        /// <returns>True if a right bracket otherwise false</returns>
        protected internal bool IsRightBrace(char c)
        {
            return (c == 41) ;
        }

    }
}
