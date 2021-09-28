using business.business.Elementos.element;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryElemento
    {
        Task<string> salvar(Elemento elemento);
        Task<string> Editar(Elemento elemento);
        IIncludableQueryable<Elemento, Elemento> includes();
    }
}