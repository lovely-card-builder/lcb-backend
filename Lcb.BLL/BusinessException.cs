namespace Lcb.BLL;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}