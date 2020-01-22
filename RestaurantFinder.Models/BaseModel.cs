using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            UniqueId = Guid.NewGuid();
            IsActive = true;
            CreatedDate = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }

        public Guid UniqueId { get; set; }


        public bool IsActive { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(1000)]
        public string UpdatedBy { get; set; }

        [StringLength(100)]
        public string DeletedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedDate { get; set; }
    }
}
