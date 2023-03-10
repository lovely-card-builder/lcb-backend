using MediatR;

namespace Lcb.BLL.MediatR.UploadImage;

public static partial class UploadImage
{
    public class Command : IRequest<string>
    {
        public string Folder { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }

        public Command(string folder, string fileName, byte[] data)
        {
            Folder = folder;
            FileName = fileName;
            Data = data;
        }
    }
}