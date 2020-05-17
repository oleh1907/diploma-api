using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DiplomaBLL.FileSave
{
    public interface IFileService
    {
        public Task<string> SaveOnDriveAsync(IFormFile file);
    }
}
