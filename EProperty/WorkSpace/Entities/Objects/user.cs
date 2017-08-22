using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Entities.Objects
{
    public class user
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phNo { get; set; }
        public DateTime createdAt { get; set; }
        public bool isApproved { get; set; }
        public DateTime approvedAt { get; set; }
        public ObjectId approvedBy { get; set; }
        public bool canApproveUsers { get; set; }
    }
}