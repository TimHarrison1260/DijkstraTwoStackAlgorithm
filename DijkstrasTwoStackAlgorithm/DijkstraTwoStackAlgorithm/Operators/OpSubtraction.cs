
namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Subtraction operator
    /// </summary>
    public class OpSubtraction: OperatorBase
    {
        public OpSubtraction() : base("Subtraction", '-' , 1, "Left")
        {}

        /// <summary>
        /// Calculate the difference between two values
        /// </summary>
        /// <param name="vLeft">First value</param>
        /// <param name="vRight">Second Value</param>
        /// <returns>Difference</returns>
        public override double Calculate(double vLeft, double vRight)
        {
            var result = vLeft-vRight;
            return result;
        }
    }
}
