using Microsoft.AspNetCore.Http;

namespace SPSS.Service.Interfaces;

public interface IImageService
{
    Task<IList<string>> MigrateToFirebaseLinkList(List<IFormFile> files);
    Task<bool> DeleteFirebaseLink(string imageUrl);
}
