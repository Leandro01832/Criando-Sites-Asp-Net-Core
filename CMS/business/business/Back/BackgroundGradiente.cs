using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.Back
{
    public class BackgroundGradiente : Background
    {
        [Display(Name = "Grau do Background Gradiente.")]
        public int Grau { get; set; }
        public List<Cor> Cores { get; set; }

    }
}
