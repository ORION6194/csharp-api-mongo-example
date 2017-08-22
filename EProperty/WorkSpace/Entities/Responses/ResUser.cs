using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Entities.Responses
{
    public class ResUser
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phNo { get; set; }
        public string password { get; set; }
        public string createdAt { get; set; }
        public bool isApproved { get; set; }
        public string approvedAt { get; set; }
        public string approvedBy { get; set; }
        public bool canApproveUsers { get; set; }
        public List<string> projectIDs { get; set; }
    }

    public class ResUsers
    {
        public List<ResUser> users { get; set; }
    }

    public class ResVersion
    {
        public bool isAllowed { get; set; }
    }
}