
namespace DijkstraTwoStackAlgorithm.Operators
{
    public class OpLeftBrace : OperatorBase
    {
        public OpLeftBrace() : base("LeftBrace", '(', 0, "None")
        {
        }

        /// <summary>
        /// No Calculation required for this, return 0.
        /// </summary>
        /// <param name="vLeft">First value</param>
        /// <param name="vRight">Second Value</param>
        /// <returns>Difference</returns>
        public override double Calculate(double vLeft, double vRight)
        {
            return 0.00D;
        }
    }
}
