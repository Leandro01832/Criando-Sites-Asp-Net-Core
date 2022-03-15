using business.business.element;
using business.business.Elementos.imagem;
using business.business.Elementos.texto;
using business.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business.Elementos.element
{
    public abstract class  Elemento : BaseModel
    {
        private string nome = "elemento";
        private string elementosDependentes = "";

        public string Nome { get { return nome; } set { nome = value; } }
        public int Ordem { get; set; }

        [JsonIgnore]
        public virtual List<DivElemento> div { get; set; }

        public int Pagina_ { get; set; }
        
        public bool Renderizar;
        [NotMapped]
        public string NomeComId { get { return Nome + " chave - " + Id.ToString(); } }

        [Display(Name = "Qual é o texto do Link?")]
        public int? TextoId { get; set; }
        public virtual Texto Texto { get; set; }

        [Display(Name = "Qual é a Imagem do Link?")]
        public int? ImagemId { get; set; }
        [JsonIgnore]
        public virtual Imagem Imagem { get; set; }

        [Display(Name = "Tabela do produto")]
        public int? TableId { get; set; }
        public Table Table { get; set; }

        [Display(Name = "Formulario do campo")]
        public int? FormularioId { get; set; }
        public virtual Formulario Formulario { get; set; }

        public virtual List<ElementoDependenteElemento> Dependentes { get; set; }
        [NotMapped]
        public string ElementosDependentes { get { return elementosDependentes; } set { elementosDependentes = value; } }

        public void IncluiElemento(Elemento elemento)
        {
            this.Dependentes.Add(new ElementoDependenteElemento { ElementoDependente = (ElementoDependente) elemento });
        }

        public virtual List<PaginaCarouselPagina> Paginas { get; set; }

        public void IncluiPagina(Pagina pagina)
        {
            this.Paginas.Add(new PaginaCarouselPagina { Pagina = pagina });
        }


    }
}
