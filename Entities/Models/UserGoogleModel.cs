using REPETITEURLINK.Entities.Data;
using System.ComponentModel.DataAnnotations;

namespace REPETITEURLINK.Entities.Models;

public class GoogleAuthRequest
{
    [Required(ErrorMessage = "token is required")]
    [MinLength(100, ErrorMessage = "The token appears to be invalid.")]
    public string IdToken { get; set; }
}