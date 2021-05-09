using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Models
{
    public class User : IEntity
    {
        [Key]
        public string UID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
