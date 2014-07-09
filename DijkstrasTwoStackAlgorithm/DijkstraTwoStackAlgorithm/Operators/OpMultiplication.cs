using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Calculates the result of multiplying v1 and v2
        /// </summary>
        /// <param name="v1">First value</param>
        /// <param name="v2">second Value</param>
        /// <returns>Result of operation</returns>
        public override double Calculate(double v1, double v2)
        {
            var result = v1*v2;
            return result;
        }
    }
}
