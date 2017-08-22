using EProperty.WorkSpace.Entities;
using EProperty.WorkSpace.Entities.Responses;
using EProperty.WorkSpace.Entities.Services;
using EProperty.WorkSpace.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EProperty
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        UserServices UserServices = new UserServices();
        public ResGeneric Register(ReqRegisterUser registeruser)
        {
            return UserServices.Register(registeruser);
        }

        public ResUser Login(ReqLoginUser loginuser)
        {
            return UserServices.Login(loginuser);
        }

        public ResUsers ListUsers(ReqListUsers userdetails)
        {
            return UserServices.ListUsers(userdetails);
        }

        public ResVersion VersionCheck(ReqVersion ReqVersion)
        {
            ResVersion rv = new ResVersion();
            if (ReqVersion.versionCode == ConstantClass.version)
                rv.isAllowed = true;
            else
                rv.isAllowed = false;
            return rv;
        }
    }
}
