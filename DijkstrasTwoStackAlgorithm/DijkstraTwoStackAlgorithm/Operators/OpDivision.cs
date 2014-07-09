using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="v1">First value</param>
        /// <param name="v2">Second Value</param>
        /// <returns>Division of v1/v2</returns>
        public override double Calculate(double v1, double v2)
        {
            var result = v1/v2;
            return result;
        }
    }
}
