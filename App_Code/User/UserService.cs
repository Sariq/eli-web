﻿using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using System.Web;


public class UserService : DatabaseActions, IUser
{
    ClientServerCommunicationActions communication = new ClientServerCommunicationActions();

    public UserForClient SignIn(User user)
    {
        var dbUser = GetUser(user);

        if (dbUser == null)
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        if (user.password != dbUser.password)
        {
            var error = new Error(Error.ErrorType.PasswordIsIncorrect);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        if (user.isRememberMe)
        {
            dbUser.isRememberMe = true;
            UpdateUser(dbUser);
        }
        else
        {
            dbUser.isRememberMe = false;
            UpdateUser(dbUser);
        }

        communication.SetTokenToHeader(dbUser);

        //// Example
        //var token2 = new ClientServerCommunicationActions().GetTokenFromHeader();
        //new ClientServerCommunicationActions().SetTokenToHeader(token2);
        //new ClientServerCommunicationActions().SetTokenToHeader_AllDetails_OnlyForExample(token2);
        //// End Example

        var returnUser = new UserForClient(dbUser);
        return returnUser;
    }

    public void SignOut()
    {
        if (HttpContext.Current.Request.Cookies["TokenId"] != null)
        {
            HttpCookie myCookie = new HttpCookie("TokenId");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }

    public User GetUserFromHeader()
    {
        User user;
        try
        {
            communication.GetTokenFromHeader();
        }
        catch
        {
            var error = new Error(Error.ErrorType.NoUserInHeader);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        var tokenId = communication.GetID_FromTokenInHeader();

        try
        {
            user = GetObject<User>(tokenId, "User").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserInHeaderIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        return user;
    }

    public void AddUser(User user)
    {
        var dbUser = GetUser(user);
        if (dbUser == null)
            InsertObject(user, "User");
        else
        {
            var error = new Error(Error.ErrorType.UserIsAlreadyExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void RemoveUser(string userId)
    {
        var dbUser = GetUser(userId);
        if (dbUser != null)
            RemoveObject(dbUser, "User");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateUser(User user)
    {
        var dbUser = GetUser(user);
        if (dbUser != null)
            UpdateObject(user, "User");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public User GetUser(User user)
    {
        try
        {
            return GetObject<User>("_userId", user.userId, "User").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public User GetUser(string userId)
    {
        try
        {
            return GetObject<User>(userId, "User").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public List<User> GetAllIUsers()
    {
        return GetAllObject<User>("User").Result;
    }

}