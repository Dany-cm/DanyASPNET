using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Pages.Rarities.Forms;

public class CreateForm
{
    [Required]
    public string RarityName { get; set; }
}