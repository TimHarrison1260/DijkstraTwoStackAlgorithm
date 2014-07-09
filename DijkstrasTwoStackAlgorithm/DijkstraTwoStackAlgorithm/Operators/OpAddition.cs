using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="v1">First Value</param>
        /// <param name="v2">Second Value</param>
        /// <returns>Sum</returns>
        public override double Calculate(double v1, double v2)
        {
            var result = v1+v2;
            return result;
        }
    }}
