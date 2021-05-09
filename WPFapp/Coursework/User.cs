using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class User
    {
        private int id_Staff { get; set; }
        private string login_Staff, name_Staff, surname_Staff,patronymic_Staff ,  password_Staff;
        private DateTime dob_Staff;
     public User() { }
     public User (string  name_Staff, string  surname_Staff, string patronymic_Staff,  string login_Staff, string password_Staff)
        {
            this.name_Staff = name_Staff;
            this.surname_Staff = surname_Staff;
            this.patronymic_Staff = patronymic_Staff;
            this.login_Staff = login_Staff;
            this.password_Staff = password_Staff;
        }
    
    
    
    
    
    }

}
