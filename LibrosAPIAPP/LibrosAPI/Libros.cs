using System.ComponentModel.DataAnnotations;
namespace LibrosAPI
{
    public class Libros
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        public int Anio { get; set; }

        [StringLength(100)]
        public string Genero { get; set; } = string.Empty;

        public int Paginas { get; set; }

        //public int Id_Editorial { get; set; }
        public int EditorialId { get; set; }
        public Editoriales? Editorial { get; set; }

        //public int Id_Autor { get; set; }
        public int AutorId { get; set; }
        public Autores? Autor { get; set; }

    }
}
