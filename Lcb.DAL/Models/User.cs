using Lcb.DAL.Misc;

namespace Lcb.DAL.Models;

public class User : IdEntity
{
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public virtual ICollection<Postcard> Postcards { get; set; }
}