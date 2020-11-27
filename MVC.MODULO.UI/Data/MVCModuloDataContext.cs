using MVC.MODULO.UI.Models;
using System.Data.Entity;

namespace MVC.MODULO.UI.Data
{
    public class MVCModuloDataContext : DbContext
    {
        public virtual DbSet<Atividade> Atividades { get; set; }

        /// <summary>
        /// Inicia conexão com PostgreSQL representa o contexto do banco de dados.
        /// </summary>

        public MVCModuloDataContext() : base(nameOrConnectionString:"PostgresDbContext")
        {
            Database.SetInitializer(new DbInitializer());
        }
    }
}
