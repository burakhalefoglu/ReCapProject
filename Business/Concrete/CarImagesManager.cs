using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager: ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal,
                                ICarImagesService carImagesService)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult AddImage(CarImages carImage)
        {

            IResult result =  BusinessRules.Run(CheckImageCount(carImage.CarId)
                );

            if (!result.Success)
            {
                return result;
            }

             _carImagesDal.Add(carImage);
            
            return new SuccessResult(Messages.DefaultSuccess);
        }

        public IResult DeleteImage(CarImages carImage)
        {
            _carImagesDal.Delete(carImage);

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
     
        public IResult UpdateImage(CarImages carImage)
        {
            _carImagesDal.Update(carImage);

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
                },Messages.DefaultSuccess);
            }
            return null;
        }
    }
}
