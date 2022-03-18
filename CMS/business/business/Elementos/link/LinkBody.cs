using business.business.Elementos.element;
using System.ComponentModel.DataAnnotations;

namespace business.business.link
{
    public class LinkBody : Elemento
    {
        [DataType(DataType.Url)]
        public string TextoLink { get; set; }
    }
}
