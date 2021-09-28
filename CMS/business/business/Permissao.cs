namespace business.business
{
    public class Permissao : BaseModel
    {
        public string NomePermissao { get; set; }
        public int Site { get; set; }
        public string UserName { get; set; }
    }
}
