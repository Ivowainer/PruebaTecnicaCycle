using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCycle.API.Config.ErrorHandler;
using PruebaTecnicaCycle.API.Dtos;
using PruebaTecnicaCycle.API.Utils;
using PruebaTecnicaCycle.Domain.Entities;
using PruebaTecnicaCycle.Domain.Services;

namespace PruebaTecnicaCycle.API.Controllers
{
    [ApiController]
    [Route("/api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IErrorHandler _errorHandler;
        public ProductoController(IProductoService productoService, IErrorHandler errorHandler)
        {
            _productoService = productoService;
            _errorHandler = errorHandler;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ICollection<ProductoDto>>> GetProductos()
        {
            try
            {
                var productos = await _productoService.GetProductos();

                return productos.Select(producto => new ProductoDto
                {
                    Precio = producto.Precio,
                    Categoria = producto.Categoria,
                    Descripcion = producto.Descripcion,
                    Estado = producto.Estado,
                    Imagen = producto.Imagen,
                    Nombre = producto.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }

        }

        [Route("{producto_id}")]
        [HttpGet]
        public async Task<ActionResult<ProductoDto>> GetProducto(int producto_id)
        {
            try
            {
                var producto = await _productoService.GetProducto(producto_id);

                return new ProductoDto
                {
                    Precio = producto.Precio,
                    Categoria = producto.Categoria,
                    Descripcion = producto.Descripcion,
                    Estado = producto.Estado,
                    Imagen = producto.Imagen,
                    Nombre = producto.Nombre
                };
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CreateProducto([FromForm] Producto producto, [FromForm] IFormFile imagen)
        {
            try
            {
                producto.Imagen = ConvertImages.ConvertImageToBase64(imagen);
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
        public async Task<ActionResult<ProductoDto>> UpdateProducto([FromForm] Producto producto, [FromForm] IFormFile imagen, int producto_id)
        {
            try
            {
                producto.Imagen = ConvertImages.ConvertImageToBase64(imagen);
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