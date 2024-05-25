using Microsoft.AspNetCore.Mvc;
using PhotoGalleryApp.Models;
using PhotoGallery.Services;
using System.Threading.Tasks;

namespace PhotoGallery.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var photos = await _photoService.GetPhotosAsync(page, pageSize);
            var totalPhotos = await _photoService.GetTotalPhotosAsync(); 
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPhotos = totalPhotos;
            return View(photos);
        }
    }
}


