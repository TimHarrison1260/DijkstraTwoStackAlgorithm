
namespace DijkstraTwoStackAlgorithm.Helpers
{
    public class ExpressionReturnCode
    {
        private bool _success;
        private string _errorMessage;

        /// <summary>
        /// Ctor: set default "successful" return
        /// </summary>
        public ExpressionReturnCode()
        {
            _success = true;
            _errorMessage = string.Empty;
        }

        /// <summary>
        /// Ctor: set specific return code
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMessage"></param>
        public ExpressionReturnCode(bool result, string errorMessage)
        {
            _success = result;
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// Gets the status of the return code: (Readonly)
        /// </summary>
        public bool Success
        { get { return _success; }}

        /// <summary>
        /// Gets the message for the return code: (readonly)
        /// </summary>
        public string ErrorMessage
        { get { return _errorMessage; }}

    }
}
