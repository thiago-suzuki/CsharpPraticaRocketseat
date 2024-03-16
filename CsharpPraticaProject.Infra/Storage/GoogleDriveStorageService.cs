using CsharpPraticaProject.Domain.Entities;
using CsharpPraticaProject.Domain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace CsharpPraticaProject.Infra.Storage;
public class GoogleDriveStorageService : IStorageService
{
    private readonly GoogleAuthorizationCodeFlow _authorization;

    public GoogleDriveStorageService(GoogleAuthorizationCodeFlow authorization)
    {
        _authorization = authorization;        
    }

    public string Upload(IFormFile file, User user)
    {
        var credential = new UserCredential(_authorization, user.Email, new Google.Apis.Auth.OAuth2.Responses.TokenResponse
        {
            AccessToken = user.AccessToken,
            RefreshToken = user.RefreshToken
        });

        var service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
        {
            ApplicationName = "CsharpPraticaGoogleDriveTest", //Substituir pelo nome do seu app
            HttpClientInitializer = credential
        });

        var driverFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = file.Name,
            MimeType = file.ContentType
        };

        var command = service.Files.Create(driverFile, file.OpenReadStream(), file.ContentType);
        command.Fields = "id";

        var response = command.Upload();

        if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
            throw response.Exception;

        return command.ResponseBody.Id;
    }
}
