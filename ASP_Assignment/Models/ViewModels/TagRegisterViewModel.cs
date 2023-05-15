using System.ComponentModel.DataAnnotations;

namespace ASP_Assignment.Models.ViewModels
{
    public class TagRegisterViewModel
    {
        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "You have to write a Tag name")]
        public string TagName { get; set; } = null!;



        public static implicit operator TagEntity(TagRegisterViewModel viewModel)
        {
            return new TagEntity
            {
                TagName = viewModel.TagName,
            };
        }
    }
}
