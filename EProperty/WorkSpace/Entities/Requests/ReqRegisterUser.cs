using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Entities
{
    public class ReqRegisterUser
    {
        public string userid { get; set; }
        public string phNo { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class ReqLoginUser
    {
        public string phNo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class ReqListUsers
    {
        public string _id { get; set; }
    }

    public class ReqVersion
    {
        public string versionCode { get; set; }
    }
}