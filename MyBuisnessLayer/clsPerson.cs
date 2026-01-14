using DataAccessesLayer;
using EncryptionTexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuisnessLayer
{
    public class clsPerson
    {

        public static int GetPersonID(string userName,string PasswordHash)
        {
            EncryptionDecriptionText.EncryptionText(ref PasswordHash);
          
         return  clsUserData.FindPerson(userName,PasswordHash);
          
            
           
        }



    }
}
