using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="v1">First value</param>
        /// <param name="v2">Second Value</param>
        /// <returns>Difference</returns>
        public override double Calculate(double v1, double v2)
        {
            var result = v1-v2;
            return result;
        }
    }
}
