using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business
{
    public abstract class BaseModel 
    {
        [Key]
        public int Id { get; set; }
        
        [NotMapped]
        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        
    }
}
