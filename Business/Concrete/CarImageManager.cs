using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _imagesDal;
      

        public CarImageManager(ICarImagesDal imagesDal)
        {
            _imagesDal = imagesDal;
           
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImages.Id));
            if (result!= null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            carImages.ImagePath = imageResult.Message;
            carImages.Date = DateTime.Now;
            _imagesDal.Add(carImages);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            var delete = _imagesDal.Get(c => c.CarId == carImages.Id);
            if (carImages == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            FileHelper.Delete(delete.ImagePath);
            _imagesDal.Delete(carImages);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_imagesDal.GetAll(), Messages.CarsImagesListed);
        }

        public IDataResult<List<CarImages>> GetByCarId(int id)
        {
                var imageResult = _imagesDal.GetAll(c => c.CarId == id);
                if (imageResult.Count >0)
                {
                    return new SuccessDataResult<List<CarImages>>(imageResult);
                }
                List<CarImages> carImages = new List<CarImages>();
                carImages.Add(new CarImages() { Id = 0, CarId = 0, ImagePath = "/images/default.jpg" });
                return new SuccessDataResult<List<CarImages>>(carImages);
            }
          

            public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_imagesDal.Get(x => x.Id == id));
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            var isImage = _imagesDal.Get(c => c.CarId == carImages.CarId);
            if (isImage == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }

            var updated = FileHelper.Update(isImage.ImagePath, file);
            if (!updated.Success)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            carImages.ImagePath = (updated.Message);
            _imagesDal.Update(carImages);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _imagesDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult("Maksimum resim sınırına ulaşıldı !");
            }
            return new SuccessResult();
        }
    }
}
