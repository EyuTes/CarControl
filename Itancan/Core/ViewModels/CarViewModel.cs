using Itancan.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Itancan.Core.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public string CarModel { get; set; }
        public int CarStatus { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<SelectListItem> SelectListCars { get; set; }
    }
}