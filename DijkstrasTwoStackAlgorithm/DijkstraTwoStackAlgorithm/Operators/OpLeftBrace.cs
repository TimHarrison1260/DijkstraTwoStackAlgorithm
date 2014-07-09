using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="v1">First value</param>
        /// <param name="v2">Second Value</param>
        /// <returns>Difference</returns>
        public override double Calculate(double v1, double v2)
        {
            return 0.00D;
        }
    }
}
