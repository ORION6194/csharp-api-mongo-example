using EProperty.WorkSpace.Entities;
using EProperty.WorkSpace.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EProperty
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Register", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGeneric Register(ReqRegisterUser registeruser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResUser Login(ReqLoginUser loginuser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "VersionCheck", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResVersion VersionCheck(ReqVersion ReqVersion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ListUsers", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResUsers ListUsers(ReqListUsers userdetails);
    }
}
