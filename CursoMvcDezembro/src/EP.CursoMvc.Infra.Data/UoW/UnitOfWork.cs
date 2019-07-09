using System;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Interfaces;

namespace EP.CursoMvc.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CursoMvcContext _context;
        private bool _disposed;

        public UnitOfWork(CursoMvcContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}