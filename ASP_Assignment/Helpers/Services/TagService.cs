using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;
using ASP_Assignment.Models.ViewModels;
using Azure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_Assignment.Helpers.Services
{
    public class TagService
    {
        #region constructor and privates
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepo, ProductTagRepository productTagRepo)
        {
            _tagRepo = tagRepo;
        }

        #endregion

        #region Get Tags

        public async Task<List<SelectListItem>> GetTagsAsync()
        {
            var tags = new List<SelectListItem>();

            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName

                });
            }
            return tags;
        }

        public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
        {
            var tags = new List<SelectListItem>();

            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName,
                    Selected = selectedTags.Contains(tag.Id.ToString())

                });
            }
            return tags;
        }

        #endregion




        #region Create
        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity { TagName = tagName };
            var result = await _tagRepo.AddAsync(entity);
            return result;
        }

        public async Task<Tag> CreateTagAsync(TagRegisterViewModel viewModel)
        {
            var entity = new TagEntity { TagName = viewModel.TagName };
            var result = await _tagRepo.AddAsync(entity);
            return result;
        }
        #endregion



        #region Get
        public async Task<Tag> GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return result;

        }
        #endregion




        #region Get All
        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();

            var list = new List<Tag>();
            foreach (var tag in result)
                list.Add(tag);

            return list;
        }
        #endregion

        #region Get By TagId



        #endregion

        #region Update
        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            if (entity != null)
            {
                entity.TagName = tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }



            return null!;
        }
        #endregion

        #region Set Tags



        #endregion


        #region Delete
        //Olika kriterier för att kunna delete

        public async Task<bool> DeleteTagAsync(int id)
        {



            var entity = await _tagRepo.GetAsync(x => x.Id == id);
            return await _tagRepo.DeleteAsync(entity);
        }


        //Delete by name
        public async Task<bool> DeleteTagAsync(string tagName)
        {



            var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return await _tagRepo.DeleteAsync(entity);
        }



        //whole tag
        public async Task<bool> DeleteTagAsync(Tag tag)
        {



            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            return await _tagRepo.DeleteAsync(entity);
        }



        #endregion




    }


}
