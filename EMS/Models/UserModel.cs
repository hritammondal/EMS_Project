using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}