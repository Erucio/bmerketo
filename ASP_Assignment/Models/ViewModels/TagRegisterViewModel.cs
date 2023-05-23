using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASP_Assignment.Models.ViewModels
{
    public class TagRegisterViewModel
    {
        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "You have to write a Tag name")]
        public string TagName { get; set; } = null!;

        public bool TagCreated { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public static implicit operator TagEntity(TagRegisterViewModel viewModel)
        {
            return new TagEntity
            {
                TagName = viewModel.TagName,
            };
        }
    }
}
