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
            Code = ' ';
            Precedence = 0;
            AssociativityLevel = "Left";
        }

        protected OperatorBase(string title, char code, int precedence, string associativityLevel)
        {
            this.Title = title;
            Code = code;
            Precedence = precedence;
            AssociativityLevel = associativityLevel;
        }

        /*
         * Properties
         */
        /// <summary>
        /// Get or Set the Operation Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set the ASCII code of the operator
        /// </summary>
        public char Code { get; set; }

        public int Precedence { get; set; }

        /// <summary>
        /// Get or set the Associativity level of the operations
        /// Add, Sub are same, but lower than Mult, Divide.
        /// </summary>
        public string AssociativityLevel { get; set; }

        /*
         * Methods
         */

        /// <summary>
        /// Perform the operation against the supplied values
        /// </summary>
        /// <param name="v1">First Value</param>
        /// <param name="v2">Second Value</param>
        /// <returns>Result of operation.</returns>
        public abstract double Calculate(double v1, double v2);

        /// <summary>
        /// Compare the operators, based upon the operator precedence
        /// </summary>
        /// <param name="other">Operator to compare to this one</param>
        /// <returns>+1 if this is greater, 0 if they are equal, -1 if this is less</returns>
        public int CompareTo(OperatorBase other)
        {
            var result = this.Precedence.CompareTo(other.Precedence);
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
