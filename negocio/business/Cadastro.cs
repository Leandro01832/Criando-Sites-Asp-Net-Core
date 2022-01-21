﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MeuProjetoAgora.business
{
    public class Cadastro 
    {
        public Cadastro()
        {
        }

        [Key]
        public int IdCadastro { get; set; }
        public virtual Requisicao Requisicao { get; set; }
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "Email é obrigatório")]
        
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Telefone é obrigatório")]
        
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Endereco é obrigatório")]
       
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Complemento é obrigatório")]
        
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Bairro é obrigatório")]
        
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Municipio é obrigatório")]
       
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "UF é obrigatório")]
        
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "CEP é obrigatório")]
        
        public string CEP { get; set; } = "";

        public void Update(Cadastro novoCadastro)
        {
            this.Bairro = novoCadastro.Bairro;
            this.CEP = novoCadastro.CEP;
            this.Complemento = novoCadastro.Complemento;
            this.Email = novoCadastro.Email;
            this.Endereco = novoCadastro.Endereco;
            this.Municipio = novoCadastro.Municipio;
            this.Nome = novoCadastro.Nome;
            this.Telefone = novoCadastro.Telefone;
            this.UF = novoCadastro.UF;
        }

        public Cadastro GetClone()
        {
            return new Cadastro
            {
                Bairro = this.Bairro,
                CEP = this.CEP,
                Complemento = this.Complemento,
                Email = this.Email,
                Endereco = this.Endereco,
                Municipio = this.Municipio,
                Nome = this.Nome,
                Telefone = this.Telefone,
                UF = this.UF
            };
        }
    }
}