using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        readonly ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }
        public IResult AddImage(CarImages carImages)
        {

            IResult result = BusinessRules.Run(CheckImageCount(carImages.CarId)
                );

            if (!result.Success)
            {
                return result;
            }

            _carImagesDal.Add(carImages);

            return new SuccessResult(Messages.DefaultSuccess);
        }

        public IResult DeleteImage(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);

            return new SuccessResult(Messages.DefaultSuccess);
        }

        public IDataResult<List<CarImages>> GetAllImages(int CarId)
        {
            IDataResult<CarImages> result = BusinessRules.RunDataResult(CheckImageExist(CarId));
            if (result != null)
                return (IDataResult<List<CarImages>>)result;

            var Images = _carImagesDal.GetAll();
            return new SuccessDataResult<List<CarImages>>(Images, Messages.DefaultSuccess);
        }

        public IResult UpdateImage(CarImages carImages)
        {
            _carImagesDal.Update(carImages);

            return new SuccessResult(Messages.DefaultSuccess);
        }

        private IResult CheckImageCount(int carId)
        {
            int CarImagesCount = _carImagesDal.GetAll(i => i.CarId == carId).Count;
            if (CarImagesCount > 4)
            {
                return new ErrorResult(Messages.DefaultError);
            }
            return null;
        }

        private IDataResult<CarImages> CheckImageExist(int carId)
        {
            int CarImagesCount = _carImagesDal.GetAll(i => i.CarId == carId).Count;
            if (CarImagesCount == 0)
            {
                return new SuccessDataResult<CarImages>(new CarImages
                {
                    ImagePath = "abcd"
                }, Messages.DefaultSuccess);
            }
            return null;
        }
    }
}
