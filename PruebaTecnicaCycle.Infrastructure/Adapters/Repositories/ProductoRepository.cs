using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Repositories;
using PruebaTecnicaCycle.Infrastructure.Database;

namespace PruebaTecnicaCycle.Infrastructure.Adapters.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CycleContext _context;

        public ProductoRepository(CycleContext context)
        {
            _context = context;
        }

        public Task<ICollection<Producto>> GetProductosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetProductoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public Task<Producto> UpdateProductoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> DeleteProductoAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}