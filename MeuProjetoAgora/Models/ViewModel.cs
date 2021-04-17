using MeuProjetoAgora.Join;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models
{
    public class ViewModel
    {
        public int IdElemento { get; set; }

        public int Pagina_ { get; set; }

        public string Nome { get; set; }

        public string elemento { get; set; }
        public string elementosDependentes { get; set; }

        public string ArquivoImagem { get; set; }
        public int? PastaImagemId { get; set; }
        public int Width { get; set; }

        public int? textoLink_ { get; set; }
        public bool UrlLink { get; set; }
        public bool Menu { get; set; }
        public string TextoLink { get; set; }
        public int? imagemLink_ { get; set; }
        public int? paginaDestinoLink_ { get; set; }

        public string EstiloTabela { get; set; }

        public string PalavrasTexto { get; set; }

        public string ArquivoVideo { get; set; }

        public int Ordem { get; set; }
        public bool Renderizar { get; set; }
        public int div_ { get; set; }

        public decimal Preco { get; set; }
        public long? estoque { get; set; }
        public string Descricao { get; set; }
        public string Segmento { get; set; }
        public string Codigo { get; set; }

        public string Placeholder { get; set; }
        public string TipoCampo { get; set; }
        
        public List<ElementoDependenteElemento> Dependentes { get; set; }
        
    }
}
