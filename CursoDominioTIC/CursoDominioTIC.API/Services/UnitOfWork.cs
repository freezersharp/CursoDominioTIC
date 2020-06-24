using CursoDominioTIC.Common.Models;

namespace CursoDominioTIC.API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private CursoDominioTICContext _context;
        private BaseRepository<Establecimiento> _establecimientos;
        private BaseRepository<Producto> _productos;

        public UnitOfWork(CursoDominioTICContext dbcontext)
        {
            _context = dbcontext;
        }

        public IRepository<Establecimiento> Establecimientos
        {
            get
            {
                return _establecimientos ?? (_establecimientos = new BaseRepository<Establecimiento>(_context));
            }
        }

        public IRepository<Producto> Productos
        {
            get
            {
                return _productos ?? (_productos = new BaseRepository<Producto>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
