using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.CustomException
{
    public sealed class ImageProcessingException : Exception
    {
        public ImageProcessingException() : base()
        {
        }

        public ImageProcessingException(string message) : base(message)
        {
        }

        public ImageProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private ImageProcessingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
