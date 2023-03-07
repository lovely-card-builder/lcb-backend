using Template.DAL.Misc;

namespace Template.DAL.Models;

public class PostcardImage : IdEntity
{
    public string FileName { get; set; }

    public int Order { get; set; }

    public Guid PostcardId { get; set; }
    
    public virtual Postcard Postcard { get; set; }
}