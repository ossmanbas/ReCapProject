using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // parametre olarak istediğimiz kadar Iresult verebiliyoruz.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //Parametreden gönderdiğim kural success olmuyorsa success olmayan hatayı dönüyorum .
                }
            }
            return null; //success oluyorsa zaten sıkıntı yok devam null.
        }
    }
}
