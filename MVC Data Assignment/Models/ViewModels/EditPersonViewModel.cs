using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.ViewModels
{
    public class EditPersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(13, MinimumLength = 10)]
        public string PhoneNum { get; set; }

        public string City { get; set; }
    }
}
