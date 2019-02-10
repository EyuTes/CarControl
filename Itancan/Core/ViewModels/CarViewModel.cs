using Itancan.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itancan.Core.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]*$", ErrorMessage = "must be letter or numeric")]
        public string RegistrationNumber { get; set; }
        [Required]
        public string CarModel { get; set; }
        public int CarStatus { get; set; }
        //[EnumDataType(typeof(CarStatus))]
        //[Display(Name = "CarStatus")]
        //public int CarStatusId { get; set; }
        // public IEnumerable<SelectListItem> CarStatusList { get; set; }
        public IEnumerable<Car> Cars { get; set; }

    }
}