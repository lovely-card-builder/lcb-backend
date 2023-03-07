using Template.DAL.Misc;

namespace Template.DAL.Models;

public class Postcard : IdEntity
{
    public string WishFrom { get; set; }

    public string WishTo { get; set; }

    public string WishText { get; set; }

    public Guid? UserId { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<PostcardImage> Images { get; set; }
}