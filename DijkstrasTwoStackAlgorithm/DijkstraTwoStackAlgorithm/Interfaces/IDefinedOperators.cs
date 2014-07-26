using DijkstraTwoStackAlgorithm.Operators;

namespace DijkstraTwoStackAlgorithm.Interfaces
{
    public interface IDefinedOperators
    {
        /// <summary>
        /// Determines if the supplied ASCII code correspondes
        /// to a valid operator
        /// </summary>
        /// <param name="operatorCode">ASCII code of the operator</param>
        /// <returns>True if a match is found, otherwise false</returns>
        bool IsOperator(char operatorCode);

        /// <summary>
        /// Retrieves the operator corresponding to the supplied
        /// ASCII code
        /// </summary>
        /// <param name="operatorCode">ASCII code of the operator</param>
        /// <returns>The operator instance if a match is found, otherwise null</returns>
        OperatorBase GetOperator(char operatorCode);
    }
}
