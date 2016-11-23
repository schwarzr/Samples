using System;

namespace UnitTesting.DotNetCore.Contract
{
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
    }
}