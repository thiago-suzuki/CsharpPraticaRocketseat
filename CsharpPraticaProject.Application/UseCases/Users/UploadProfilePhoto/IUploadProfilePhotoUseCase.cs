using Microsoft.AspNetCore.Http;

namespace CsharpPraticaProject.Application.UseCases.Users.UploadProfilePhoto;
public interface IUploadProfilePhotoUseCase
{
    public void Execute(IFormFile file);
}
