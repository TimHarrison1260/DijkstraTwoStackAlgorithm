
namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Multiplication operator
    /// </summary>
    public class OpMultiplication: OperatorBase
    {
        public OpMultiplication() : base("Multiplication", '*' , 2, "Left")
        {}

        /// <summary>
        /// Calculates the result of multiplying vLeft and vRight
        /// </summary>
        /// <param name="vLeft">First value</param>
        /// <param name="vRight">second Value</param>
        /// <returns>Result of operation</returns>
        public override double Calculate(double vLeft, double vRight)
        {
            var result = vLeft*vRight;
            return result;
        }
    }
}
