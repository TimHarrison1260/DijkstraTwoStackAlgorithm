using System.Collections.Generic;

namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Holds the operations defined to the calculator.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Adding a new operation to the calculator involves
    /// 1.  defining a new operator which derives from the OperatorBase 
    ///     class and suppliying the appropriate properties and calculation 
    ///     method
    /// 2.  Add the operator to this DefinedOperators class
    /// 3.  It may be necessary to perform some conversion when tokenising
    ///     the operater identifier, for user functions say.
    /// </para>
    /// </remarks>
    public class DefinedOperators
    {
        private readonly List<OperatorBase> _operators;

        public DefinedOperators()
        {
            //  Add defined operators
            _operators = new List<OperatorBase>
            {
                new OpLeftBrace(),
                new OpAddition(),
                new OpSubtraction(),
                new OpMultiplication(),
                new OpDivision()
            };
        }

        /// <summary>
        /// Determines if the supplied ASCII code correspondes
        /// to a valid operator
        /// </summary>
        /// <param name="operatorCode">ASCII code of the operator</param>
        /// <returns>True if a match is found, otherwise false</returns>
        public bool IsOperator(char operatorCode)
        {
            foreach (var op in _operators)
            {
                if (operatorCode == op.Code)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieves the operator corresponding to the supplied
        /// ASCII code
        /// </summary>
        /// <param name="operatorCode">ASCII code of the operator</param>
        /// <returns>The operator instance if a match is found, otherwise null</returns>
        public OperatorBase GetOperator(char operatorCode)
        {
            foreach (var op in _operators)
            {
                if (operatorCode == op.Code)
                    return op;
            }
            return null;
        }
    }
}
