using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using MeuProjetoAgora.business;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.business.Elementos
{
    public class Campo : Elemento
    {
        public string Placeholder { get; set; }
        public string TipoCampo { get; set; }
    }
}