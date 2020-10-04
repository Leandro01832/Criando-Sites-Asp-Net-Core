
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
   public class Formulario
    {
        [Key]
        public int IdForm { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Qual o link que vai chamar o formulario?")]
        public int link_ { get; set; }
        [Display(Name = "Estilo do formulário")]
        public string Model { get; set; }
        
        [JsonIgnore]
        [ForeignKey("link_")]
        public virtual Link link { get; set; }
        [JsonIgnore]
        public virtual List<Campo> Campos { get; set; }

        [Range(1, 10000, ErrorMessage = "Escolha em qual bloco vai estar o texto")]
        [Display(Name = "Colocar em qual bloco o formulario?")]
        public int div_ { get; set; }
        [ForeignKey("div_")]
        [JsonIgnore]
        public virtual Div div { get; set; }

        public List<Campo> CamposPadrao(int modelo)
        {
            
            List<Campo> Campos = new List<Campo>();
            if (modelo == 1)
            {
                Campo Nome = new Campo
                {
                    Nome = "Nome",
                    Placeholder = "Informe seu Nome",
                    Tipo = "text"
                };
                Campo Email = new Campo
                {
                    Nome = "Email",
                    Placeholder = "Informe seu Email",
                    Tipo = "text"
                };

                Campos.Add(Nome);
                Campos.Add(Email);
                return Campos;
            }

            if (modelo == 2)
            {
                Campo Nome = new Campo
                {
                    Nome = "Nome",
                    Placeholder = "Informe seu Nome",
                    Tipo = "text"
                };
                Campo Email = new Campo
                {
                    Nome = "Email",
                    Placeholder = "Informe seu Email",
                    Tipo = "text"
                };
                Campo Cpf = new Campo
                {
                    Nome = "CPF",
                    Placeholder = "Informe seu CPF",
                    Tipo = "text"
                };

                Campos.Add(Nome);
                Campos.Add(Email);
                Campos.Add(Cpf);
                return Campos;
            }

            if (modelo == 3)
            {
                Campo Nome = new Campo
                {
                    Nome = "Nome",
                    Placeholder = "Informe seu Nome",
                    Tipo = "text"
                };
                Campo Email = new Campo
                {
                    Nome = "Email",
                    Placeholder = "Informe seu Email",
                    Tipo = "text"
                };
                Campo Cpf = new Campo
                {
                    Nome = "CPF",
                    Placeholder = "Informe seu CPF",
                    Tipo = "text"
                };
                Campo Cep = new Campo
                {
                    Nome = "CEP",
                    Placeholder = "Informe seu CEP",
                    Tipo = "text"
                };


                Campos.Add(Nome);
                Campos.Add(Email);
                Campos.Add(Cpf);
                Campos.Add(Cep);
                return Campos;
            }

            return null;            
        }

    }
}
