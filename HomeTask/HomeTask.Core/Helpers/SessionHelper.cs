using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using HomeTask.Core.Helpers.SessionKeys;

namespace HomeTask.Core.Helpers
{
    public static class CacheHelper
    {

        public static void SetUserName(this Cache cache, string userName)
        {
            cache[SessionKey.UserName] = userName;
        }

        public static string GetUserName(this Cache cache)
        {
            return cache[SessionKey.UserName] == null ? "" : (string)cache[SessionKey.UserName];
        }

        public static void SetUserID(this Cache cache, object ID)
        {
            cache[SessionKey.UserName] = ID;
        }

        public static object GetUserID(this Cache cache)
        {
            return cache[SessionKey.UserId] == null ? "" : (string)cache[SessionKey.UserId];
        }

        public static object GetInstitutionID(this Cache cache)
        {
            return cache[SessionKey.InstitutionID];
        }

        public static void SetInstitutionID(this Cache cache, object ID)
        {
            cache[SessionKey.InstitutionID] = ID;
        }

        public static void SetTeacherID(this Cache cache, object teacherID)
        {
            cache[SessionKey.TeacherID] = teacherID;
        }

        public static object GetTeacherID(this Cache cache)
        {
            return cache[SessionKey.TeacherID];
        }

        public static void SetStudentID(this Cache cache, object studentID)
        {
            cache[SessionKey.StudentID] = studentID;
        }

        public static object GetStudentID(this Cache cache)
        {
            return cache[SessionKey.StudentID];
        }
    }
}
