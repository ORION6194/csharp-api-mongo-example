using EProperty.WorkSpace.Entities.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Helpers
{
    public class Logger
    {
        static public void Log(string user_id, string module, string function, string message)
        {
            try
            {
                var dberror = new MongoHelper<error>();
                var objerror = new error();
                objerror.user_id = user_id;
                objerror.datetime = DateTime.UtcNow;
                objerror.module = module;
                objerror.function = function;
                objerror.message = message;
                dberror.Collection.Insert(objerror);
            }
            catch (Exception e) {
               
            }
        }
    }
}