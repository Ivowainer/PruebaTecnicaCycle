using Microsoft.AspNetCore.Mvc;

using PruebaTecnicaCycle.API.Config.ErrorHandler;
using PruebaTecnicaCycle.API.Dtos;

using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Services;

namespace PruebaTecnicaCycle.API.Controllers
{
    [ApiController]
    [Route("api/producto")]
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
                var newProducto = await _productoService.CreateProducto(producto);

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

        [Route("{producto_id}")]
        [HttpPut]
        public async Task<ActionResult<ProductoDto>> UpdateProducto([FromBody] Producto producto, int producto_id)
        {
            try
            {
                var newProducto = await _productoService.UpdateProducto(producto_id, producto);

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

        [Route("{producto_id}")]
        [HttpDelete]
        public async Task<ActionResult<ProductoDto>> DeleteProducto(int producto_id)
        {
            try
            {
                var newProducto = await _productoService.DeleteProducto(producto_id);

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