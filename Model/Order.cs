using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PostgresSQL.API.Model
{

    [Table("order")]
    public class Order
    {

        public Guid id
        {
            get;
            set;
        }

        public Guid product_id
        {
            get;
            set;
        }

        public string? address
        {
            get;
            set;
        }
        public string? name
        {
            get;
            set;
        }

        public string? phone
        {
            get;
            set;
        }

        public DateTime createdon
        {
            get;
            set;
        }

        public virtual Product? product
        {
            get;
            set;
        }


    }
}