namespace Lcb.BLL.Misc;

public class ErrorDto
{
    public string Error { get; set; }

    public ErrorDto(string error)
    {
        Error = error;
    }
}