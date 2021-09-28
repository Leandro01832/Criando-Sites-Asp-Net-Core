using business.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business.Elementos.element
{
    public abstract class  Elemento : BaseModel
    {
        public string Nome { get; set; }
        public int Ordem { get; set; }

        [JsonIgnore]
        public virtual List<DivElemento> div { get; set; }

        public int Pagina_ { get; set; }

        [NotMapped]
        public string tipo { get; set; }

        public bool Renderizar;





    }
}
