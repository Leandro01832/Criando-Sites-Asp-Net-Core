using System.ComponentModel.DataAnnotations;

namespace business.business
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
