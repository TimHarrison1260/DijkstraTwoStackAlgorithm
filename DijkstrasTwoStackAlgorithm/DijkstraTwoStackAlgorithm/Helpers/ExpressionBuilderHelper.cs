using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraTwoStackAlgorithm.Interfaces;

namespace DijkstraTwoStackAlgorithm.Helpers
{
    public class ExpressionBuilderHelper
    {
        private readonly IDefinedOperators _definedOperators;

        public ExpressionBuilderHelper(IDefinedOperators definedOperators)
        {
            if (definedOperators == null)
                throw new ArgumentNullException("definedOperators", "No valid definedOperators ");
            _definedOperators = definedOperators;
        }

        /// <summary>
        /// Determines if character is numeric
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected internal bool IsNumeric(char c)
        {
            //  To be a value it must be 0, 9 inclusive => 48, 57
            //  Add . and , => 44, 46
            var result = (c < 58 && c > 47) || (c == 44) || (c == 46);
            return result;
        }

        /// <summary>
        /// Determines if the '-' is a leading minus sign.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected internal bool IsLeadingMinus(char c, string expression)
        {
            if (c != 45) return false;                  // Not minus sign

            if (expression.Length == 0) return true;    //  first character in expression

            var previousChar = expression[expression.Length - 1];
            //  Not 1st char then the previous must be Operator or (.
            var result = (_definedOperators.IsOperator(previousChar) || IsLeftBrace(previousChar));
            return result;
        }

        /// <summary>
        /// Determins if placing a decimal point to the expression is valid.  
        /// ie. no other decimal already added for the current number.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected internal bool IsDecimalValid(char c, string expression)
        {
            if (c != 46) return true;                   //  Not a decimal point
            if (expression.Length == 0) return true;    //   first character in expression
            //  Get first non-numeric position is expression
            //  loop through the characters of the expression until not numeric
            //  if char is decimal
            //      return false
            //  otherwise
            //      continue
            var start = expression.Length - 1;
            for (int i = start; i >= 0 && IsNumeric(expression[i]); i--)
            {
                if (expression[i] == 46) return false;
                if (expression[i] == 44) //  comma found
                {
                    if (i != expression.Length - 1 - 3) return false;   //  Comma found, not 3 digits separating.
                    return true;                                        //  There are 3 digits separating, no further checking needed
                }
            }
            return true;
        }

        /// <summary>
        /// Determines if adding a comma to the expression is valid
        /// ie a decimal point does not already exist
        /// or, if another comma exists, there must be 3 digits between them
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected internal bool IsCommaValid(char c, string expression)
        {
            if (c != 44) return true;               //  Not a comma, no checking required
            if (expression.Length == 0) return true;

            for (int i = (expression.Length - 1); i >= 0 && IsNumeric(expression[i]); i--)
            {
                if (expression[i] == 46) return false;  //  decimal point found, comma's invalid after point.
                if (expression[i] == 44)
                {
                    if (i != expression.Length - 1 - 3) return false;   // comma found and not 3 digits seperation.
                    return true;                                        //  There are 3 digits separating, no further checking needed
                }
            }
            return true;
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
            return (c == 41);
        }

    }
}
