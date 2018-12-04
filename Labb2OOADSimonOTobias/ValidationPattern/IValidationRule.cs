using System;
namespace Labb2OOADSimonOTobias.ValidationPattern
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
