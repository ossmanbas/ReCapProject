using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Araçlar Listelendi";
        public static string CarImageAdded = "Araç Resmi Eklendi";
        public static string CarsImagesListed = "Araç Resimleri Listelendi";
        public static string CarImagesUpdated = "Araç Resmi Güncellendi";
        public static string CarImagesDeleted = "Araç Resmi Silindi";
        internal static string MailNameAlreadyExists = "Bu mail adresine kayıtlı hesap var !";
        internal static string BrandCountExceded = "Marka sayısı aşıldığı için yeni araba eklenemiyor !";
        internal static string ImageNotFound="Resim bulunamadı";
        internal static string ImageDeleted="Resim Silindi";
        internal static string ImageUpdated="Resim Güncellendi";
    }
}
