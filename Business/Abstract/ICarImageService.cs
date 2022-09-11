using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
        IResult Add(IFormFile file ,CarImages carImages);
        IResult Update(IFormFile file,CarImages carImages);
        IResult Delete(CarImages carImages);
    }

}
