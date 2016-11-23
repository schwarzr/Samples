using System;
using System.Runtime.Serialization;

namespace UnitTesting.WebApi.Contract
{
    [Serializable]
    public class FileReferenceAlreadyExistsException : Exception
    {
        public FileReferenceAlreadyExistsException()
            : base("The File Reference already exists")
        {
        }

        public FileReferenceAlreadyExistsException(string message) : base(message)
        {
        }

        public FileReferenceAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileReferenceAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}