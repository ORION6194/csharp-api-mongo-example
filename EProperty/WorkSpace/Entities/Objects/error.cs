using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Entities.Objects
{
    public class error
    {
        public ObjectId _id { get; set; }
        public string user_id { get; set; }
        public DateTime datetime { get; set; }
        public string module { get; set; }
        public string function { get; set; }
        public string message { get; set; }
    }
}