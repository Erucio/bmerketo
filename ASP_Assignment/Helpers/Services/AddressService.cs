﻿using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;

namespace ASP_Assignment.Helpers.Services;

public class AddressService
{
    #region privates and constructors
    private readonly AddressRepository _addressRepo;
    private readonly UserAddressRepository _userAddressRepository;

    public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepository)
    {
        _addressRepo = addressRepo;
        _userAddressRepository = userAddressRepository;
    }
    #endregion


    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
    {
        var entity = await _addressRepo.GetAsync(x => 
        x.StreetName == addressEntity.StreetName &&
        x.PostalCode == addressEntity.PostalCode &&
        x.City == addressEntity.City
        );

        entity ??= await _addressRepo.AddAsync(addressEntity);
        return entity!;     
    }

    public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
    {
        await _userAddressRepository.AddAsync(new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = addressEntity.Id,
        });
    }
}
