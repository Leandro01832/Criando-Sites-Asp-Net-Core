

using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.Models.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly IConfiguration configuration;
        protected readonly ApplicationDbContext contexto;
        protected readonly DbSet<T> dbSet;

        

        public BaseRepository(IConfiguration configuration,
            ApplicationDbContext contexto)
        {
            this.configuration = configuration;
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }

        
    }
}
