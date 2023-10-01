using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Pages.Editions.Forms;

public class CreateForm
{
    [Required]
    public string Edition { get; set; }
}