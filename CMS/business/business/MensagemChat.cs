namespace business.business
{
    public class MensagemChat : BaseModel
    {
        public int Pagina { get; set; }
        public string NomeUsuario { get; set; }
        public string Mensagem { get; set; }
    }
}
