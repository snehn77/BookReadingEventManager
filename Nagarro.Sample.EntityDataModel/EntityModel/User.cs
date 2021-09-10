using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nagarro.Sample.EntityDataModel
{
    public class User : Domain
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<BookReadingEvent> BookEvents { get; set; }
    }
}
