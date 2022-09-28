using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Verdiğimiz passwordün hash ini oluşturuyo.
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash,out byte[] passwordSalt) // Bir password alıp , onu Hashleyip, Saltlayıp geri döndürücez.
            //out değer türündeki veriyi referans olarak metota geçmek için kullanılır. (ref de aynı işlemi yapar ancak başlangıç değeri ister out istemez)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//ComputeHash metodu Byte [] şeklinde veri istediği için Encoding işlemi yapıyoruz.
            }
        }

        //Sonradan sisteme girmek isteyen kişinin yazdığı şifrenin bizim yukarda hashleyip DB ye kaydettiğimiz şifreyle eşleşip eşleşmediğini kontrol ettiğimiz metot.
        public static bool VerifyPasswordHash
            (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
