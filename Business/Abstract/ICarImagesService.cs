using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAllImages(int CarId);
        IResult UpdateImage(CarImages carImages);
        IResult DeleteImage(CarImages carImages);
        IResult AddImage(CarImages carImages);
    }
}
