using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Repositories;
using PruebaTecnicaCycle.Domain.Services;

namespace PruebaTecnicaCycle.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Task<Producto> GetProductoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Producto>> GetProductosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CreateProductoAsync(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Categoria) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Imagen))
            {
                throw new ArgumentException("None of the fields can be empty");
            }

            return _productoRepository.CreateProductoAsync(producto);
        }

        public Task<Producto> DeleteProductoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> UpdateProductoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}