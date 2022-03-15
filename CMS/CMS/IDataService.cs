using System;
using System.Threading.Tasks;

namespace CMS
{
    interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}
