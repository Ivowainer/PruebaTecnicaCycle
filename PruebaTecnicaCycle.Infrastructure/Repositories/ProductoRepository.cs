using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Repositories;
using PruebaTecnicaCycle.Infrastructure.Database;

namespace PruebaTecnicaCycle.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CycleContext _context;

        public ProductoRepository(CycleContext context)
        {
            _context = context;
        }

        public Task<ICollection<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetProducto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto> UpdateProducto(int id, Producto producto)
        {
            var productoToUpdate = await _context.Productos.FindAsync(id) ?? throw new InvalidOperationException("Producto not found.");

            productoToUpdate.Nombre = producto.Nombre;
            productoToUpdate.Precio = producto.Precio;
            productoToUpdate.Categoria = producto.Categoria;
            productoToUpdate.Descripcion = producto.Descripcion;
            productoToUpdate.Imagen = producto.Imagen;
            productoToUpdate.Estado = producto.Estado;

            await _context.SaveChangesAsync();

            return productoToUpdate;
        }

        public Task<Producto> DeleteProducto(int id)
        {
            throw new NotImplementedException();
        }

    }
}