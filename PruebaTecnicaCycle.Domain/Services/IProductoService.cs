using PruebaTecnicaCycle.Domain.Entities;

namespace PruebaTecnicaCycle.Domain.Services
{
    public interface IProductoService
    {
        Task<ICollection<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task<Producto> CreateProducto(Producto producto);
        Task<Producto> UpdateProducto(int id, Producto producto);
        Task<Producto> DeleteProducto(int id);
    }
}