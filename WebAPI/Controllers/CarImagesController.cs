using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpPost("addimages")]
        public void AddImage(CarImages carImage)
        {
            _carImagesService.AddImage(carImage);
        }

        [HttpPost("updateimage")]
        public void UpdateImage(CarImages carImage)
        {
            _carImagesService.UpdateImage(carImage);
        }

        [HttpPost("deleteimage")]
        public void DeleteImage(CarImages carImage)
        {
            _carImagesService.DeleteImage(carImage);
        }

    }
}
