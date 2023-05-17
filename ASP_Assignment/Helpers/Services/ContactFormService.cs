using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Migrations;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;

namespace ASP_Assignment.Helpers.Services
{
    public class ContactFormService
    {
        private readonly ContactFormRepository _contactFormRepo;



        public ContactFormService(ContactFormRepository contactFormRepo)
        {
            _contactFormRepo = contactFormRepo;
        }



        #region Save form to DB
        public async Task<Comment> AddAsync(ContactViewModel viewModel)
        {
            var entity = new CommentEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Company = viewModel.CompanyName,
                CommentText = viewModel.CommentText,
                RememberMe = viewModel.RememberMe,
                DateTime = DateTime.UtcNow
            };



            var savedEntity = await _contactFormRepo.AddAsync(entity);



            var contactFormEntry = new Comment
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber,
                Company = savedEntity.Company,
                CommentText = savedEntity.CommentText,
                RememberMe = savedEntity.RememberMe,
                DateTime = savedEntity.DateTime
            };



            return contactFormEntry;
        }
        #endregion



        #region Get all comments for admin



        public async Task<IEnumerable<CommentEntity>> GetAllAsync()
        {
            return await _contactFormRepo.GetAllAsync();
        }



        #endregion
    }
}
