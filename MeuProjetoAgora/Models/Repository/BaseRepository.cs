

using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuProjetoAgora.Models.Repository
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
