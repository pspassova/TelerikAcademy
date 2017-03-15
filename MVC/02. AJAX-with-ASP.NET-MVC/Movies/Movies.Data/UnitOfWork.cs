using Movies.Data.Contracts;
using System;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Movies.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMoviesDbContext context;

        public UnitOfWork(IMoviesDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));

            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChangesAsync();
        }
    }
}
