using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreManuallyRetrieveSwaggerSchema.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public City City { get; set; }
        
        public List<City> Cities { get; set; }
    }
}