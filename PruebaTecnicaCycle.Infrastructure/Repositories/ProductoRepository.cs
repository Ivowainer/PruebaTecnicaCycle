using Dapper;
using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Repositories;
using PruebaTecnicaCycle.Infrastructure.Database;

namespace PruebaTecnicaCycle.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CycleContext _context;
        private readonly DapperContext _contextDapper;

        public ProductoRepository(CycleContext context, DapperContext contextDapper)
        {
            _context = context;
            _contextDapper = contextDapper;
        }

        public async Task<ICollection<Producto>> GetProductos()
        {
            /* var query = $"SELECT * FROM {_contextDapper.Data}"; */
            var query = $"EXECUTE Catalogo.ListarProductos;";
            using var connection = _contextDapper.CreateConnection();
            var productos = await connection.QueryAsync<Producto>(query);
            return productos.ToList();
        }

        public async Task<Producto> GetProducto(int id)
        {
            var query = $"SELECT * FROM {_contextDapper.Data} WHERE Id = {id}";
            using var connection = _contextDapper.CreateConnection();
            var producto = await connection.QueryAsync<Producto>(query);
            return producto.FirstOrDefault()!;
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

        public async Task<Producto> DeleteProducto(int id)
        {
            var productoToDelete = await _context.Productos.FindAsync(id) ?? throw new InvalidOperationException("Producto not found.");
            _context.Productos.Remove(productoToDelete);
            await _context.SaveChangesAsync();

            return productoToDelete;
        }
    }
}