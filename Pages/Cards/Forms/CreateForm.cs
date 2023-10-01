using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Pages.Cards.Forms;

public class CreateForm
{
    [Required] public int EditionId { get; set; }
    [Required] public int RarityId { get; set; }
    [Required] public string CardName { get; set; }
    [Required] public int CardNumber { get; set; }
}