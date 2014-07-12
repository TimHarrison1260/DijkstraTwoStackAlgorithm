
namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Division operator
    /// </summary>
    public class OpDivision : OperatorBase
    {
        public OpDivision() : base("Division", '/', 2, "Left")
        {
        }

        /// <summary>
        /// Calculate the divison of two values
        /// </summary>
        /// <param name="vLeft">First value</param>
        /// <param name="vRight">Second Value</param>
        /// <returns>Division of vLeft/vRight</returns>
        public override double Calculate(double vLeft, double vRight)
        {
            var result = vLeft/vRight;
            return result;
        }
    }
}
