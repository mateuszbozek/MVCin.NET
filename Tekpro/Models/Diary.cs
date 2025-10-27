using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Tekpro.Models
{
    public class Diary
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Proszę podać tytuł")]
        //[StringLength(100,MinimumLength =3, ErrorMessage ="Tytuł musi zawierać od 3 do 100 znaków")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
