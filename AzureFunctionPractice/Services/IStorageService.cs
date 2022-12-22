namespace AzureFunctionPractice.Services
{
    public interface IStorageService
    {

        Task Upload(IFormFile file);
    }
}
