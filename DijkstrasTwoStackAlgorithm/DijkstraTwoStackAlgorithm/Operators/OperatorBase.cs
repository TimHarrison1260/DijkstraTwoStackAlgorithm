using System;
using System.Collections.Generic;

namespace DijkstraTwoStackAlgorithm.Operators
{
    /// <summary>
    /// Base abstract operator class, defines the properties and methods, Calculate is abstract
    /// to be overridden in derived class.
    /// </summary>
    public abstract class OperatorBase: IComparable<OperatorBase>, IComparer<OperatorBase>
    {
        protected OperatorBase()
        {
            Title = string.Empty;
            Token = ' ';
            Precedence = 0;
            Associativity = "Left";
        }

        protected OperatorBase(string title, char token, int precedence, string associativity)
        {
            Title = title;
            Token = token;
            Precedence = precedence;
            Associativity = associativity;
        }

        /*
         * Properties
         */
        /// <summary>
        /// Get or Set the Operation Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set the ASCII Token of the operator
        /// </summary>
        public char Token { get; set; }

        /// <summary>
        /// Get or set the Precedence of the operators.
        /// Add, Sub are same, but lower than Mult, Divide.
        /// </summary>
        public int Precedence { get; set; }

        /// <summary>
        /// Get or set the Associativity of the operations
        /// Add, Sub, Mult and Divide are all Left Associative.
        /// </summary>
        public string Associativity { get; set; }

        /*
         * Methods
         */

        /// <summary>
        /// Perform the operation against the supplied values
        /// </summary>
        /// <param name="vLeft">First Value</param>
        /// <param name="vRight">Second Value</param>
        /// <returns>Result of operation.</returns>
        public abstract double Calculate(double vLeft, double vRight);

        /// <summary>
        /// Compare the operators, based upon the operator precedence
        /// </summary>
        /// <param name="other">Operator to compare to this one</param>
        /// <returns>+1 if this is greater, 0 if they are equal, -1 if this is less</returns>
        public int CompareTo(OperatorBase other)
        {
            var result = Precedence.CompareTo(other.Precedence);
            return result;
        }

        /// <summary>
        /// Compare two operators, based upon the operator precedence
        /// </summary>
        /// <param name="x">first operator</param>
        /// <param name="y">Second operator</param>
        /// <returns>+1 if x >y, 0 if x=y, -1 if x>y</returns>
        public int Compare(OperatorBase x, OperatorBase y)
        {
            var result = x.CompareTo(y);
            return result;
        }

    }
}
