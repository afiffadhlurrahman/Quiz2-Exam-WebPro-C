using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quiz2.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Owner { get; set; }
        public string RegisNum { get; set; }
        public string Creator { get; set; }
    }
}
