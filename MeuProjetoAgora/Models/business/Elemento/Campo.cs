using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using MeuProjetoAgora.Models.business;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business.Elemento
{
    public class Campo : Elemento
    {
        public string Placeholder { get; set; }
        public string TipoCampo { get; set; }
    }
}