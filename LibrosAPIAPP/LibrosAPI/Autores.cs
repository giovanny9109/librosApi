using System.ComponentModel.DataAnnotations;

namespace LibrosAPI
{
    public class Autores
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        [StringLength(50)]
        public string Ciudad { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
