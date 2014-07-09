using System;
using System.Text;
using System.Collections.Generic;
using DijkstraTwoStackAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// AlgorithmIntegrationTests provide a sample of the strings the 
    /// Algorithm is expected to parse and calculate.
    /// </summary>
    [TestClass]
    public class AlgorithmIntegrationTests
    {
        private Algorithm _algorithm;

        [TestInitialize]
        public void Initialise()
        {
            //  Create new instance for each test, to avoid
            //  interaction between tests.
            _algorithm = new Algorithm();
        }


        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void EmptyInput_Returns_Zero()
        {
            //  Arrange
            string expression = @"";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(0D, result, "Expected Zero, as empty string entered");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Additions_Only_Returns_OK()
        {
            //  Arrange
            string expression = @"1+2+3";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(6D, result, "Expected 6, 1+2+3 = 6");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Same_Precedence_Only_Returns_OK()
        {
            //  Arrange
            string expression = @"1*4/2";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(2D, result, "Expected 2, 1*4/2 = 2");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Mixed_Precedence_Returns_OK()
        {
            //  Arrange
            string expression = @"1+4/2";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(3D, result, "Expected 3, 1+4/2 = 3");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Braces_Mixed_Precedence_Returns_OK()
        {
            //  Arrange
            string expression = @"1+(4/2)";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(3D, result, "Expected 3, 1+(4/2) = 3");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Complex_Braces_Mixed_Precedence_Returns_OK()
        {
            //  Arrange
            string expression = @"9*(2+(3 - 2)*3)";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(45D, result, "Expected 45, 9*(2+(3-2)*3) = 45");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Complex1_Braces_Mixed_Precedence_Returns_OK()
        {
            //  Arrange
            string expression = @"1+(3+(6/2)-1)*4*5";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(101D, result, "Expected 101, 1+(3+(6/2)-1)*4*5 =101");
        }

        [TestMethod]
        [TestCategory("IntegrationTest_Algorithm")]
        public void Input_Complex2_Braces_Mixed_Precedence_Returns_OK()
        {
            //  Arrange
            string expression = @"1+(3+6/2-1)*4*5";

            //  Act
            var result = _algorithm.Interpret(expression);

            //  Assert
            Assert.AreEqual(101D, result, "Expected 101, 1+(3+6/2-1)*4*5 =101");
        }



    }
}
