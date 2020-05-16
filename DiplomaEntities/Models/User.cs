using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaEntities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
