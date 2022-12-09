using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ETrade.Dto;

namespace ETrade.Repos.Concretes
{
    public class UsersRep<T> : BaseRepository<Users>, IUsersRep where T : class
    {
        TradeContext _db;
        public UsersRep(TradeContext db) : base(db)
        {
            _db = db;
        }

        public Users CreateUser(Users user)
        {
            //böyle bir user varsa hatalıdır kaydetmicez
            Users selectedUser=_db.Set<Users>().FirstOrDefault(x=> x.Mail == user.Mail);
            if (selectedUser != null)//hata
            {
                user.Error=true;
            }
            else
            {
                user.Error=false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";
            return user;
        }

        public UserDTO Login(string Mail, string Password)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == Mail);
            UserDTO user = new UserDTO();
            user.Mail = Mail;
            if (selectedUser != null)
            {

                user.Error = false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                   
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            else user.Error = true;
            return user;
        }
    }
}
