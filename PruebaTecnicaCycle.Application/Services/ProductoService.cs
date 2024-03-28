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

        public Task<Producto> GetProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Producto>> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CreateProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Categoria) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Imagen))
                throw new ArgumentException("None of the fields can be empty");

            return _productoRepository.CreateProducto(producto);
        }

        public Task<Producto> UpdateProducto(int id, Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Categoria) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Imagen))
                throw new ArgumentException("None of the fields can be empty");

            return _productoRepository.UpdateProducto(id, producto);
        }

        public Task<Producto> DeleteProducto(int id)
        {
            return _productoRepository.DeleteProducto(id);
        }
    }
}