using System.ComponentModel.DataAnnotations;

namespace business.business.link
{
    public class LinkBody : Link
    {
        [DataType(DataType.Url)]
        public string TextoLink { get; set; }
    }
}
