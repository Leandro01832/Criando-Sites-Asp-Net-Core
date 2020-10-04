using MeuProjetoAgora.Models.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public long? estoque { get; set; }
        [Display(Name ="Em qual tabela vai ser colocado o produto?")]
        public int table_ { get; set; }
        [JsonIgnore]        
        public virtual List<ProdutoImagem> Imagens { get; set; }
        [JsonIgnore]
        [ForeignKey("table_")]
        public virtual Table tabela { get; set; }
        [JsonIgnore]
        public virtual List<ItemRequisicao> Itens { get; set; }

        

        public void IncluiImagem(Imagem imagem)
        {
            this.Imagens.Add(new ProdutoImagem { Imagem = imagem });
        }
    }
}