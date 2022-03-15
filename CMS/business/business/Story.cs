using System.Collections.Generic;

namespace business.business
{
    public class Story : BaseModel
    {
        public string Nome { get; set; }
        public virtual List<Pagina> Pagina { get; set; }

    }
}
