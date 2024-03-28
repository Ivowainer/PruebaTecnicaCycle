using Microsoft.AspNetCore.Mvc;

using PruebaTecnicaCycle.API.Config.ErrorHandler;
using PruebaTecnicaCycle.API.Dtos;

using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Services;

namespace PruebaTecnicaCycle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IErrorHandler _errorHandler;
        public ProductoController(IProductoService productoService, IErrorHandler errorHandler)
        {
            _productoService = productoService;
            _errorHandler = errorHandler;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CreateProducto([FromBody] Producto producto)
        {
            try
            {
                var newProducto = await _productoService.CreateProductoAsync(producto);

                return new ProductoDto
                {
                    Precio = newProducto.Precio,
                    Categoria = newProducto.Categoria,
                    Descripcion = newProducto.Descripcion,
                    Estado = newProducto.Estado,
                    Imagen = newProducto.Imagen,
                    Nombre = newProducto.Nombre
                };
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }

        }
    }
}