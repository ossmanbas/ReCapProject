using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper 
    {
        //    public void Delete(string FilePath)
        //    {
        //        if (File.Exists(FilePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
        //        {
        //            File.Delete(FilePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
        //        }
        //    }

        //    public string Update(IFormFile file, string FilePath, string root)
        //    {
        //        if (File.Exists(FilePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
        //        {
        //            File.Delete(FilePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
        //        }
        //        return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.


        //}

        //public string Upload(IFormFile file, string root)
        //    {
        //        if (file.Length > 0)//file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderil mi gönderilmemiş diye test işlemi yapıldı.
        //        {
        //            if (!Directory.Exists(root))//Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
        //            {                           //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
        //                                        //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur
        //                Directory.CreateDirectory(root);
        //            }
        //            string extension = Path.GetExtension(file.FileName);//Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
        //            string guid = GuidHelper.GuidHelper.GuidCreater(); //Core.Utilities.Helpers.GuidHelper klasürünün içinde ki GuidManager klasörüne giderseniz burada satırda ne yaptığımızı anlayacaksınız
        //            string filePath = guid + extension;//Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 

        //            using (FileStream fileStream = File.Create(root + filePath))//Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
        //            {
        //                file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
        //                fileStream.Flush();//arabellekten siler.
        //                return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
        //            }
        //        }
        //        return null;

        //}

            private static string _currentFileDirectory = Environment.CurrentDirectory + "\\wwwroot";
            private static string _folderName = "\\images\\";

            public static IResult Add(IFormFile file)
            {
                var fileExist = CheckFileExists(file);
                if (fileExist.Message != null)
                {
                    return new ErrorResult(fileExist.Message);
                }

                var type = Path.GetExtension(file.FileName);
                var typeValid = CheckFileTypeValid(type);
                var randomName = Guid.NewGuid().ToString();

                if (typeValid.Message != null)
                {
                    return new ErrorResult(typeValid.Message);
                }

                CheckFileDirectoryExist(_currentFileDirectory + _folderName);
                CreateImageFile(_currentFileDirectory + _folderName + randomName + type, file);
                return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
            }

            public static IResult Update(string imagePath, IFormFile file)
            {
                var fileExist = CheckFileExists(file);
                if (fileExist.Message != null)
                {
                    return new ErrorResult(fileExist.Message);
                }

                var type = Path.GetExtension(file.FileName);
                var typeValid = CheckFileTypeValid(type);
                var randomName = Guid.NewGuid().ToString();

                if (typeValid.Message != null)
                {
                    return new ErrorResult(typeValid.Message);
                }

                DeleteOldImageFile((_currentFileDirectory + imagePath).Replace("/", "\\"));
                CheckFileDirectoryExist(_currentFileDirectory + _folderName);
                CreateImageFile(_currentFileDirectory + _folderName + randomName + type, file);

                return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));

            }

            public static IResult Delete(string path)
            {
                DeleteOldImageFile((_currentFileDirectory + path).Replace("/", "\\"));
                return new SuccessResult();
            }


            //Verification Methods

            private static IResult CheckFileTypeValid(string type)
            {
                if (type != ".jpeg" && type != ".png" && type != ".jpg")
                {
                    return new ErrorResult("File Type Is Wrong!");
                }

                return new SuccessResult();
            }

            private static IResult CheckFileExists(IFormFile file)
            {
                if (file != null && file.Length > 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult("File Not Found!");
            }

            private static void DeleteOldImageFile(string directory)
            {
                if (File.Exists(directory.Replace("/", "\\")))
                {
                    File.Delete(directory.Replace("/", "\\"));
                }
            }

            private static void CheckFileDirectoryExist(string directory)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            private static void CreateImageFile(string directory, IFormFile file)
            {
                using (FileStream fs = File.Create(directory))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
        }

    }

