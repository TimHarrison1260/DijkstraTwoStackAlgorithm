
namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Addition operator
    /// </summary>
    public class OpAddition: OperatorBase
    {
        public OpAddition() : base("Addition", '+', 1, "Left")
        {}

        /// <summary>
        /// Calculate sum of two values
        /// </summary>
        /// <param name="vLeft">First Value</param>
        /// <param name="vRight">Second Value</param>
        /// <returns>Sum</returns>
        public override double Calculate(double vLeft, double vRight)
        {
            var result = vLeft+vRight;
            return result;
        }
    }}
