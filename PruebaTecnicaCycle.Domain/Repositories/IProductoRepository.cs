using PruebaTecnicaCycle.Domain.Entities;

namespace PruebaTecnicaCycle.Domain.Repositories
{
    public interface IProductoRepository
    {
        Task<ICollection<Producto>> GetProductosAsync();
        Task<Producto> GetProductoAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto> UpdateProductoAsync(int id);
        Task<Producto> DeleteProductoAsync(int id);
    }
}