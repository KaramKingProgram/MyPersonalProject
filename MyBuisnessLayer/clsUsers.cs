using DataAccessesLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using EncryptionTexts;
namespace MyBuisnessLayer
{
    public class clsUsers
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public static bool Register(string firstName, string lastName,string Email,
                            DateTime dateOfBirth, string country, string phone,
                            string username, string password)
        {
            int PersonID = clsPersonData.AddNewPerson(firstName, lastName, dateOfBirth, country, phone);

            if (PersonID == -1)
            {
                return false;
            }
            EncryptionDecriptionText.EncryptionText(ref password);


            clsUserData.AddNewUser(username, password, Email, PersonID);

            return true;

        }
        //public static bool AddNewUser(string username, string password,string Email,int PersonID)
        //{
        //   EncryptionDecriptionText.EncryptionText(ref password);

        //    return clsUserData.AddNewUser(username,password,Email,PersonID);
        //}
        public static bool IsUserExsit(string UserName,string PasswordHash)
        {
            EncryptionDecriptionText.EncryptionText(ref PasswordHash);

            return clsUserData.CheckIsUserExsit(UserName, PasswordHash);
        }



    }
}
