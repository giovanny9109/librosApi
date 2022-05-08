using System.ComponentModel.DataAnnotations;

namespace LibrosAPI
{
    public class Editoriales
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public int Libros_registrados { get; set; }
    }
}
