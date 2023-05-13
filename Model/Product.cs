using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresSQL.API.Model
{

    [Table("product")]
    public class Product
    {
        [Key, Required]
        public Guid id
        {
            get;
            set;
        }
        [Required]
        public string? name
        {
            get;
            set;
        }

        public string? brand
        {
            get;
            set;
        }

        public string? size
        {
            get;
            set;
        }

        public double? price
        {
            get;
            set;
        }

        public virtual ICollection<Order>? orders
        {
            get;
            set;
        }
    }
}