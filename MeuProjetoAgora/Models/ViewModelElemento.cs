using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models
{
    public class ViewModelElemento
    {
        public string Nome { get; set; }

        public string elemento { get; set; }

        public string ArquivoImagem { get; set; }
        public int? PastaImagemId { get; set; }

        public int? textoLink_ { get; set; }
        public bool UrlLink { get; set; }
        public string TextoLink { get; set; }
        public int? imagemLink_ { get; set; }
        public int? paginaDestinoLink_ { get; set; }

        public string EstiloTable { get; set; }

        public string PalavrasTexto { get; set; }

        public string ArquivoVideo { get; set; }

        public int Ordem { get; set; }
        public bool Renderizar { get; set; }
        public int div { get; set; }
        public int? div_ { get; set; }


    }
}
