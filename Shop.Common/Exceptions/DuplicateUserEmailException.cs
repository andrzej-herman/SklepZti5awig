namespace Shop.Common.Exceptions;

public class DuplicateUserEmailException : Exception
{
    public DuplicateUserEmailException(string message) : base(message) {}
}