using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bulkAction.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Boolean isChecked { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int price { get; set; }
    }
}
