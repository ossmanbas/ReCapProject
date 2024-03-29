﻿using Core.Entities.Concreate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi ";
        public static string CarNameInvalid = "Araç ismi geçersiz ";
        public static string MaintenanceTime = "Sistem Bakımda ";
        public static string CarsListed = "Araçlar Listelendi ";
        public static string CarImageAdded = "Araç Resmi Eklendi ";
        public static string CarsImagesListed = "Araç Resimleri Listelendi ";
        public static string CarImagesUpdated = "Araç Resmi Güncellendi ";
        public static string CarImagesDeleted = "Araç Resmi Silindi ";
        public static string MailNameAlreadyExists = "Bu mail adresine kayıtlı hesap var !";
        public static string BrandCountExceded = "Marka sayısı aşıldığı için yeni araba eklenemiyor !";
        public static string ImageNotFound="Resim bulunamadı ";
        public static string ImageDeleted="Resim Silindi ";
        public static string ImageUpdated="Resim Güncellendi ";
        public static string CarNotFound="Araç Bulunamadı ";
        public  static string AuthorizationDenied="Yetkiniz yok !";
        public static string UserRegistered="Kayıt Başarılı !";
        public static string UserNotFound="Kullanıcı Bulunamadı !";
        public static string PasswordError="Hatalı Parola !";
        public static string SuccessfulLogin="Giriş Başarılı !";
        public static string UserAlreadyExists="Kullanıcı Mevcut !";
        public static string AccessTokenCreated="Access Token oluşturuldu !";
    }
}
