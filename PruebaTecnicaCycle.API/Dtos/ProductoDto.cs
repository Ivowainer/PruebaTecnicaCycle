namespace PruebaTecnicaCycle.API.Dtos
{
    public class ProductoDto
    {
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public string? Categoria { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public bool? Estado { get; set; }
    }
}