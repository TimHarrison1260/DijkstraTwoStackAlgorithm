
namespace DijkstraTwoStackAlgorithm.Interfaces
{
    public interface IAlgorithm
    {
        /// <summary>
        /// Dijkstra's Two-Stack Algorithm for interpreting
        /// mathematical expressions, written as strings.
        /// </summary>
        /// <param name="expression">The string representation of the mathematical expression</param>
        /// <returns>Result of the expression</returns>
        double Calculate(string expression);

        /// <summary>
        /// Converts the input expressions (infix format) to Rpn format
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        string ConvertToRpn(string expression);
    }
}
