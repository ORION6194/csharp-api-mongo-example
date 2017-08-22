using MongoDB.Bson;
using MongoDB.Driver.Builders;
using EProperty.WorkSpace.Entities.Objects;
using EProperty.WorkSpace.Entities.Responses;
using EProperty.WorkSpace.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Entities.Services
{
    public class UserServices
    {
        public ResGeneric Register(ReqRegisterUser registeruser)
        {
            try
            {
                if (UtilityClass.IsNull(registeruser.phNo))
                    return UtilityClass.GetResponse("Failure", "Pass phNo", "");
                if (UtilityClass.IsNull(registeruser.name))
                    return UtilityClass.GetResponse("Failure", "Pass name", "");
                if (UtilityClass.IsNull(registeruser.email))
                    return UtilityClass.GetResponse("Failure", "Pass email", "");
                if (UtilityClass.IsNull(registeruser.password))
                    return UtilityClass.GetResponse("Failure", "Pass password", "");
                /*var dbuser = new MongoHelper<user>();
                var objUser = dbuser.Collection.Find(Query.Or(Query.EQ("phNo", registeruser.phNo), Query.EQ("email", registeruser.email))).FirstOrDefault();
                if (objUser == null)
                {
                    objUser = new user();
                    objUser._id = new ObjectId();
                    objUser.name = registeruser.name.Trim();
                    objUser.createdAt = DateTime.UtcNow;
                    objUser.phNo = registeruser.phNo.Trim();
                    objUser.email = registeruser.email.Trim();
                    objUser.password = registeruser.password;
                    objUser.isApproved = false;
                    objUser.canApproveUsers = false;
                    
                    dbuser.Collection.Insert(objUser);
                    return UtilityClass.GetResponse("Success", "User registered successfully", objUser._id.ToString());
                }
                else
                    return UtilityClass.GetResponse("Failure", "User already registered", objUser._id.ToString());
                    */
                return UtilityClass.GetResponse("Success","Data Received Successfully",registeruser.name);
            }
            catch (Exception e)
            {
                Logger.Log(registeruser.phNo, "UserServices", "Register", e.Message);
                return UtilityClass.GetResponse("Error", e.Message, "");
            }
        }
        public ResUser Login(ReqLoginUser loginuser)
        {
            ResUser ResUser = new ResUser{_id=""};
            try
            {
                if (UtilityClass.IsNull(loginuser.phNo) && UtilityClass.IsNull(loginuser.email))
                    return ResUser;
                if (UtilityClass.IsNull(loginuser.password))
                    return ResUser;
                if (UtilityClass.IsNull(loginuser.phNo)) loginuser.phNo = "";
                if (UtilityClass.IsNull(loginuser.email)) loginuser.email = "";
                //TODO write a query and put the response data in ResUser object
            }
            catch (Exception e)
            {
                Logger.Log(UtilityClass.IsNull(loginuser.phNo) ? loginuser.email : loginuser.phNo, "UserServices", "Login", e.Message);
            }
            return ResUser;
        }
        public ResUsers ListUsers(ReqListUsers userdetails)
        {
            ResUsers ResUsers = new ResUsers { users = new List<ResUser>() };
            try
            {
                if (UtilityClass.IsNull(userdetails._id))
                    return ResUsers;

                /*var dbuser = new MongoHelper<user>();
                var objUser = dbuser.Collection.Find(Query.EQ("_id", ObjectId.Parse(userdetails._id))).FirstOrDefault();
                if (objUser != null && objUser.canApproveUsers)
                {
                    var objUsers = dbuser.Collection.FindAll().ToList();
                    foreach (var user in objUsers)
                        if (!user.canApproveUsers)
                            ResUsers.users.Add(new ResUser
                            {
                                _id = user._id.ToString(),
                                name = user.name,
                                email = user.email,
                                phNo = user.phNo,
                                createdAt = UtilityClass.GetTime(user.createdAt),
                                isApproved = user.isApproved,
                                approvedAt = UtilityClass.GetTime(user.approvedAt),
                                approvedBy = user.approvedBy.ToString(),
                                canApproveUsers = user.canApproveUsers,
                                password=user.password,
                                projectIDs=new List<string>()
                            });

                }*/

                //TODO write a query to fetch list of users from database and put it in ResUsers List
            }
            catch (Exception e)
            {
                Logger.Log(userdetails._id, "UserServices", "ListUsers", e.Message);
            }
            return ResUsers;
        }
    }

}