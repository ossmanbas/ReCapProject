using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _imagesDal;

        public CarImageManager(ICarImagesDal imagesDal)
        {
            _imagesDal = imagesDal;
        }

        public IResult Add(CarImages carImages)
        {
            _imagesDal.Add(carImages);
            return new  SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            _imagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_imagesDal.GetAll(), Messages.CarsImagesListed);
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_imagesDal.Get(x => x.Id == id));
        }

        public IResult Update(CarImages carImages)
        {
            _imagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }
    }
}
