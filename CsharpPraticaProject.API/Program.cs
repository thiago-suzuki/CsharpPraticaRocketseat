using CsharpPraticaProject.Application.UseCases.Users.UploadProfilePhoto;
using CsharpPraticaProject.Domain.Storage;
using CsharpPraticaProject.Infra.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using dotenv.net;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUploadProfilePhotoUseCase, UploadProfilePhotoUseCase>();
builder.Services.AddScoped<IStorageService>(options =>
{
    var clientId = Environment.GetEnvironmentVariable("ClientId");
    var clientSecret = Environment.GetEnvironmentVariable("ClientSecret");

    var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId = clientId,
            ClientSecret = clientSecret
        },
        Scopes = [Google.Apis.Drive.v3.DriveService.Scope.Drive],
        DataStore = new FileDataStore("CsharpPraticaGoogleDriveTest") //Substituir pelo nome do seu app
    });

    return new GoogleDriveStorageService(apiCodeFlow);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
