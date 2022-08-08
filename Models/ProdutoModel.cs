using System.ComponentModel.DataAnnotations;

namespace RestTest.Models
{
    public class ProdutoModel
    {
        [Key]
        public int? id { get; set; }
        public string? nome { get; set; }
        public int? preco { get; set; }
    }
}
