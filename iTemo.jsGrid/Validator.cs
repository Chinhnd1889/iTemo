﻿using System.Text;

namespace iTemo.jsGrid
{
    public class Validator
    {
        private readonly string _validator;
        private readonly bool _isBuiltInValidator;
        private string _message;
        private bool _isMessageFunction;

        private string _param;
        private bool _paramIsText;

        /// <summary>
        /// validate is a string as validate rule name or validation function or a validation configuration object or an array of validation configuration objects. Read more details about validation in the Validation section.
        /// </summary>
        /// <param name="validator">built-in or custom validator</param>
        /// <param name="isBuiltIn">true if validator is built-in refe jsGrid.MVC.Enums.BuiltInValidator</param>
        public Validator(string validator, bool isBuiltIn)
        {
            _validator = validator;
            _isBuiltInValidator = isBuiltIn;
        }

        /// <summary>
        /// validation message or a function(value, item) returning validation message
        /// </summary>
        /// <param name="message">message string or message function</param>
        /// <param name="isFunction">true if message is function</param>
        /// <returns></returns>
        public Validator SetMessage(string message, bool isFunction)
        {
            _message = message;
            _isMessageFunction = isFunction;
            return this;
        }

        /// <summary>
        /// param a plain object with parameters to be passed to validation function
        /// </summary>
        /// <param name="param">param used for validate</param>
        /// <param name="isText">true for Pattern validate, other is false</param>
        /// <returns></returns>
        public Validator SetParam(string param, bool isText)
        {
            _param = param;
            _paramIsText = isText;
            return this;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_message) && string.IsNullOrEmpty(_param))
            {
                return _isBuiltInValidator ? $"\"{_validator}\",\r\n" : $"{_validator},\r\n";
            }
            else
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(_isBuiltInValidator
                    ? $"validator: \"{_validator}\","
                    : $"validator: {_validator},");

                if (!string.IsNullOrEmpty(_message))
                {
                    stringBuilder.AppendLine(
                        !_isMessageFunction ? $"message: \"{_message}\"," : $"message: {_message},");
                }

                if (!string.IsNullOrEmpty(_param))
                {
                    stringBuilder.AppendLine(_paramIsText ? $"param: \"{_param}\"," : $"param: {_param},");
                }
                stringBuilder.AppendLine("},");

                return stringBuilder.ToString();
            }
        }
    }
}
