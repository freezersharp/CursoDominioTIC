using CursoDominioTIC.Common.Models;

namespace CursoDominioTIC.API.Services
{
    public interface IUnitOfWork
    {
        IRepository<Establecimiento> Establecimientos { get; }
        IRepository<Producto> Productos { get; }
        void Save();
    }
}
