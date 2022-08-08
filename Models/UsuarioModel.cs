using System.ComponentModel.DataAnnotations;

namespace RestTest.Models
{
    public class UsuarioModel
    {
        [Key]
        public int idUsuario { get; set; }
        public string? nomeUsuario { get; set; }
        public int? telefoneUsuario { get; set; }
    }
}
