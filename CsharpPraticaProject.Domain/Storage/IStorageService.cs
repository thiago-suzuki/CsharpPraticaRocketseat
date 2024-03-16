using CsharpPraticaProject.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CsharpPraticaProject.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile file, User user);
}
