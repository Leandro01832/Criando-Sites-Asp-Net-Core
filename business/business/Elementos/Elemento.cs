
using MeuProjetoAgora.Join;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business.Elementos
{
   public abstract class  Elemento
    {
        [Key]
        public int IdElemento { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }

        [JsonIgnore]
        public virtual List<DivElemento> div { get; set; }

        public int Pagina_ { get; set; }

        [NotMapped]
        public string tipo { get; set; }

        [NotMapped]
        public string ElementosDependentes { get; set; }

        [JsonIgnore]
        public virtual List<ElementoDependenteElemento> Despendentes { get; set; }
        

        public void IncluiElemento(ElementoDependente elemento)
        {
            this.Despendentes.Add(new ElementoDependenteElemento { ElementoDependente = elemento });
        }


    }
}
