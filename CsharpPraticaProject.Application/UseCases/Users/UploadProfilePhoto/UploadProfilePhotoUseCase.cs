using CsharpPraticaProject.Domain.Entities;
using CsharpPraticaProject.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CsharpPraticaProject.Application.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;

    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
       _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (!isImage)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = Environment.GetEnvironmentVariable("Name"),
            Email = Environment.GetEnvironmentVariable("Email"),
            RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
            AccessToken = Environment.GetEnvironmentVariable("AccessToken")
        };
    }
}
