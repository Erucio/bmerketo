﻿using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Migrations;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;

namespace ASP_Assignment.Helpers.Services;

public class ContactFormService
{
    #region privates and constructors
    private readonly ContactFormRepository _contactFormRepo;



    public ContactFormService(ContactFormRepository contactFormRepo)
    {
        _contactFormRepo = contactFormRepo;
    }
    #endregion

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
    #region Get Comments



    public async Task<IEnumerable<CommentEntity>> GetAllAsync()
    {
        return await _contactFormRepo.GetAllAsync();
    }




    public async Task<CommentEntity> GetCommentByIdAsync(int Id)
    {
        return await _contactFormRepo.GetAsync(entity => entity.Id == Id);
    }

    public async Task<bool> DeleteAsync(CommentEntity commentEntity)
    {
        return await _contactFormRepo.DeleteAsync(commentEntity);
    }
    #endregion

}
