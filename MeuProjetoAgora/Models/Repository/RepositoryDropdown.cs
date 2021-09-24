
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Data;
using Microsoft.Extensions.Configuration;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryDropdown
    {
        Dropdown RetornaDropdown(ViewModelElemento elemento);
    }



    public class RepositoryDropdown : BaseRepository<Dropdown>, IRepositoryDropdown
    {

        public RepositoryDropdown(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Dropdown RetornaDropdown(ViewModelElemento elemento)
        {
            return new Dropdown
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = elemento.elementosDependentes,
                Despendentes = elemento.Dependentes
            };
        }
    }
}