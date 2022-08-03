using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace rComponents
{
    public interface IValidatableControl
    {
        ValidationType ValidationType { get; set; }
        string FieldName { get; set; }
        void Validate();
    }

    public enum ValidationType
    {
        None,
        NotEmpty,
        InRange
    }

    public class ValidationException : Exception
    {
        public Control Control { get; set; }
        public new string Message { get; set; }

        public ValidationException()
        {
        }

        public ValidationException(Control control, string message) : base(message)
        {
            Control = control;
            Message = message;
        }
    }


}