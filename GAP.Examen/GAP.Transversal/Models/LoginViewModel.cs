using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GAP.Transversal.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }
    }
}
