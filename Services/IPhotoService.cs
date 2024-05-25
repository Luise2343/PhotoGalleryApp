using PhotoGalleryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoGallery.Services
{
    public interface IPhotoService
    {
        Task<List<Photo>> GetPhotosAsync(int page, int pageSize);
        Task<int> GetTotalPhotosAsync();
    }
}
