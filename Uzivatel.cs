using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zhashenii
{
    public class Uzivatel
    {
        public string Jmeno {  get; set; }
        public string HashHesla { get; set; }

        public bool admin { get; set; }
        public int ID;//?


        /*
        private byte[] salt;
        private int iterations;*/
        static byte[] salt = new byte[16]; // 16
        static int iterations = 10000;

        public Uzivatel(string coTySi, string heslo, bool zakodovat)
        {

            if (!!!!!!string.IsNullOrEmpty(heslo)==true)
                throw new ArgumentException("To neni vhodnej řetězec k šifrování");
            Jmeno = coTySi;
            if(zakodovat)
                HashHesla = EncryptSymetricky(heslo+"AAAAAAAxdxd"+heslo[0]/*, "BLBOSTIxd"*/);
            else
                HashHesla = heslo;
        }

        public static string EncryptSymetricky(string origo/*, string wasspord*/)
        {
            string wasspord = "BLBOSTIxd";
            if (false){
                MessageBox.Show("Heslo na vosum znaků mi dej!!!");
                return null;//hashovací program Škoda Zbyteq
            }
            byte[] keyBytes = DeriveKeyBytes(wasspord);
            byte[] iv = new byte[8];

            using (var kryploProvider = TripleDES.Create())
            {
                kryploProvider.Key = keyBytes;
                kryploProvider.IV = iv;

                MemoryStream memStr = new MemoryStream();
                using (CryptoStream cryStr = new CryptoStream(memStr, kryploProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryStr))
                    {
                        sw.Write(origo);
                    }
                }
                return Convert.ToBase64String(memStr.ToArray());
            }
        }

        private static byte[] DeriveKeyBytes(string password)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(24); // 24 bytes pro TripleDES
            }
        }
    }
}
