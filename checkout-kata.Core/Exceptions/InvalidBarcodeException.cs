using System;
using System.Runtime.Serialization;

namespace checkout_kata.Core
{
    [Serializable]
    public class InvalidBarcodeException : Exception
    {
        public InvalidBarcodeException()
        {
        }

        public InvalidBarcodeException(string message) : base(message)
        {
        }

        public InvalidBarcodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBarcodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}