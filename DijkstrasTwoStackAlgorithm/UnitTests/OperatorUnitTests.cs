using System;
using DijkstraTwoStackAlgorithm.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /*
     * A sample of Unit tests for the Calculate methods of each operator
     */
    [TestClass]
    public class OperatorUnitTests
    {
        [TestMethod]
        [TestCategory("OperatorCalculation")]
        public void OpMultiplication_Calculate_OK()
        {
            //  Arrange
            var op = new OpMultiplication();
            var valueLeft = 4D;
            var valueRight = 2D;

            //  Act
            var result = op.Calculate(valueLeft, valueRight);

            //  Assert
            Assert.AreEqual(8D, result, "Expected '4*2' to equal 8");
        }

        [TestMethod]
        [TestCategory("OperatorCalculation")]
        public void OpAddition_Calculate_OK()
        {
            //  Arrange
            var op = new OpAddition();
            var valueLeft = 4D;
            var valueRight = 2D;

            //  Act
            var result = op.Calculate(valueLeft, valueRight);

            //  Assert
            Assert.AreEqual(6D, result, "Expected '4+2' to equal 6");
        }

        [TestMethod]
        [TestCategory("OperatorCalculation")]
        public void OpLeftBrace_Calculate_NoException()
        {
            //  Arrange
            var op = new OpLeftBrace();
            var valueLeft = 4D;
            var valueRight = 2D;

            //  Act
            var result = op.Calculate(valueLeft, valueRight);

            //  Assert
            Assert.AreEqual(0D, result, "Expected Left Brace operator to do nothing, return Zero");
        }

        [TestMethod]
        [TestCategory("OperatorComparison")]
        public void OperatorPrecedence_Compare_Higher_OK()
        {
            //  Arrange
            var opHigher = new OpMultiplication();
            var opLower = new OpAddition();

            //  Act
            var result = opHigher.CompareTo(opLower);

            //  Assert
            Assert.AreEqual(1, result, "Expected 1: mult should have higher precedence than addition");
        }

        [TestMethod]
        [TestCategory("OperatorComparison")]
        public void OperatorPrecedence_Compare_Lower_To_Higher_OK()
        {
            //  Arrange
            var opHigher = new OpMultiplication();
            var opLower = new OpAddition();

            //  Act
            var result = opLower.CompareTo(opHigher);

            //  Assert
            Assert.AreEqual(-1, result, "Expected -1: Add should have lower precedence than multiplication");
        }

        [TestMethod]
        [TestCategory("OperatorComparison")]
        public void OperatorPrecedence_Compare_Equal_Higher_OK()
        {
            //  Arrange
            var opHigher = new OpSubtraction();
            var opLower = new OpAddition();

            //  Act
            var result = opLower.CompareTo(opHigher);

            //  Assert
            Assert.AreEqual(0, result, "Expected 0: Add and Sub should have same precedence");
        }


    }
}
