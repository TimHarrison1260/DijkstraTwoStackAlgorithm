using System;
using DijkstraTwoStackAlgorithm;
using DijkstraTwoStackAlgorithm.Interfaces;
using DijkstraTwoStackAlgorithm.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ExpressionBuilderUnitTests
    {
        private IExpressionBuilder _expressionBuilder;
        //private IDefinedOperators _definedOperators;

        [TestInitialize]
        public void Initialise()
        {
            //  Arrange
            //_definedOperators = new DefinedOperators();
            _expressionBuilder = new ExpressionBuilder();   //  new DefinedOperators());
        }


        [TestMethod]
        [TestCategory("ExpressionBuilder")]
        public void AddDigit_OK()
        {
            //  Act
            var result0 = _expressionBuilder.AddDigit('0');
            var result9 = _expressionBuilder.AddDigit('9');
            var resulta = _expressionBuilder.AddDigit('a');

            var resultMinus = _expressionBuilder.AddDigit('-');

            var resultComma = _expressionBuilder.AddDigit(',');
            //  Try adding a second comma, vefore decimal, but less that 3 chars from last one: fails
            var resultComma2Fail = _expressionBuilder.AddDigit(',');
            //  Add 3 numbers then another comma: should be OK
            var result1 = _expressionBuilder.AddDigit('1');
            var result2 = _expressionBuilder.AddDigit('2');
            var result3 = _expressionBuilder.AddDigit('3');
            var resultComma3 = _expressionBuilder.AddDigit(',');

            var resultDecimal = _expressionBuilder.AddDigit('.');   //  Fails, immediately after comma

            //  Add 3 numbers then decimal: should be OK
            var result1A = _expressionBuilder.AddDigit('1');
            var result2A = _expressionBuilder.AddDigit('2');
            var result3A = _expressionBuilder.AddDigit('3');
            var resultDecimal1A = _expressionBuilder.AddDigit('.');

            //  Try adding a second decimal point to the number
            var resultdecimal2 = _expressionBuilder.AddDigit('.');

            //  Assert
            Assert.IsTrue(result0.Success, "Expected '0' to be added.");
            Assert.IsTrue(result9.Success, "Expected '9' to be added.");
            Assert.IsFalse(resulta.Success, "Not expected 'a' to be added.");

            Assert.IsFalse(resultMinus.Success, "Not Expected '-' to be added. as previous digits exist in expression");

            Assert.IsTrue(resultComma.Success, "Expected comma to be added.");
            Assert.IsFalse(resultComma2Fail.Success, "Expected 2nd comma to be rejected, less than 3 digits between last one");
            Assert.IsTrue(resultComma3.Success, "Expected 2nd comma with 3 interveining digits to be added");

            Assert.IsFalse(resultDecimal.Success, "Expected decimal to fail, not 3 digits between it and previous comma");
            Assert.IsTrue(resultDecimal1A.Success, "Expected dcimal to be added, 3 digits between it and previous comma.");
            Assert.IsFalse(resultdecimal2.Success, "Not expected decimal to be added, invalid for 2 decimal points.");
        }

        [TestMethod]
        [TestCategory("ExpressionBuilder")]
        public void AddDigit_LeadingMinusSign_OK()
        {
            var result = _expressionBuilder.AddDigit('-');

            Assert.IsTrue(result.Success, "Expected '-' to be added, first char in expression.");
        }

        [TestMethod]
        [TestCategory("ExpressionBuilder")]
        public void AddRightBrace_OK()
        {
            var resultFirstChar_Fail = _expressionBuilder.AddRightBrace(')');
            var result = _expressionBuilder.AddDigit('1');
            result = _expressionBuilder.AddOperator('*');
            result = _expressionBuilder.AddDigit('2');

            var resultAfterdigit_Faile_NoLeftBrace = _expressionBuilder.AddRightBrace(')');

            result = _expressionBuilder.AddOperator('(');
            result = _expressionBuilder.AddDigit('3');
            result = _expressionBuilder.AddOperator('+');

            var resultAfterOperator_Fail = _expressionBuilder.AddRightBrace('(');

            result = _expressionBuilder.AddDigit('3');

            var resultAfterDigit_OK_LeftBraceToBalance = _expressionBuilder.AddRightBrace(')');


            Assert.IsFalse(resultFirstChar_Fail.Success, "Not Expected ')' to be added: first char in expression");
            Assert.IsFalse(resultAfterdigit_Faile_NoLeftBrace.Success, "Not expected ')' to be added: no left brace to balance with");
            Assert.IsFalse(resultAfterOperator_Fail.Success, "Not expected ')' to be added: immediately after operator");
            Assert.IsTrue(resultAfterDigit_OK_LeftBraceToBalance.Success, "Expected ')' to be added");

        }


        [TestMethod]
        [TestCategory("ExpressionBuilder")]
        public void AddOperator_OK()
        {
            var resultFirstChar = _expressionBuilder.AddOperator('+');
            var resultFirstLEftBrace = _expressionBuilder.AddOperator('(');
            var resultOppAfterLeftBrace = _expressionBuilder.AddOperator('*');

            var result1 = _expressionBuilder.AddDigit('1');
            var resultOppAfterDigit = _expressionBuilder.AddOperator('*');
            var resultOppAfterOp = _expressionBuilder.AddOperator('/');

            var result2 = _expressionBuilder.AddDigit('2');
            var resultAddRightBrace = _expressionBuilder.AddRightBrace(')');
            var resultOpAfterRightBrace = _expressionBuilder.AddOperator('*');


            Assert.IsFalse(resultFirstChar.Success, "Not Expected operator to be added: first char in expression");
            Assert.IsTrue(resultFirstLEftBrace.Success, "Expected '(' can be added as first operator to empty expression");
            Assert.IsFalse(resultOppAfterLeftBrace.Success, "Not expected operator to be added: Cannot add operator immediately after left brace");

            Assert.IsTrue(resultOppAfterDigit.Success, "Expected operator to be added: prev char was a digit");
            Assert.IsFalse(resultOppAfterOp.Success, "Not expected operator to be added: prev char was an operator");

            Assert.IsTrue(resultOpAfterRightBrace.Success, "Expected operator to be added: after right brace");

        }

        [TestMethod]
        [TestCategory("ExpressionBuilder")]
        public void AddLeftBraceAfterOperator_OK()
        {
            var result = _expressionBuilder.AddDigit('1');
            result = _expressionBuilder.AddOperator('*');
            var resultLeftAfterOp = _expressionBuilder.AddOperator('(');

            Assert.IsTrue(resultLeftAfterOp.Success, "Expected '(' to be added, open braces immediately after operator");
        }

    }
}
