using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Models
{
    public class User
    {
        public User()
        {
            this.Roles = new List<Role>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual List<Role> Roles { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
