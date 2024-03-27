using PruebaTecnicaCycle.Domain.Entities;

namespace PruebaTecnicaCycle.Domain.Services
{
    public interface IProductoService
    {
        Task<ICollection<Producto>> GetProductosAsync();
        Task<Producto> GetProductoAsync(int id);
        Task<Producto> CreateProductoAsync();
        Task<Producto> UpdateProductoAsync(int id);
        Task<Producto> DeleteProductoAsync(int id);
    }
}