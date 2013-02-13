using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HomeTask.Core.Helpers.SessionKeys;

namespace HomeTask.Core.Helpers
{
    public static class SessionHelper
    {

        public static void SetUserName(this HttpSessionStateBase session, string userName)
        {
            session[SessionKey.UserName] = userName;
        }

        public static string GetUserName(this HttpSessionStateBase session)
        {
            return session[SessionKey.UserName] == null ? "" : (string) session[SessionKey.UserName];
        }

        public static void SetUserID(this HttpSessionStateBase session, object ID)
        {
            session[SessionKey.UserName] = ID;
        }

        public static object GetUserID(this HttpSessionStateBase session)
        {
            return session[SessionKey.UserName] == null ? "" : (string)session[SessionKey.UserName];
        }

        public static object GetInstitutionID(this HttpSessionStateBase session)
        {
            return session[SessionKey.InstitutionID];
        }

        public static void SetInstitutionID(this HttpSessionStateBase session, object ID)
        {
            session[SessionKey.InstitutionID] = ID;
        }

        public static void SetTeacherID(this HttpSessionStateBase session, object teacherID)
        {
            session[SessionKey.TeacherID] = teacherID;
        }

        public static object GetTeacherID(this HttpSessionStateBase session)
        {
            return session[SessionKey.TeacherID];
        }

        public static void SetStudentID(this HttpSessionStateBase session, object studentID)
        {
            session[SessionKey.StudentID] = studentID;
        }

        public static object GetStudentID(this HttpSessionStateBase session)
        {
            return session[SessionKey.StudentID];
        }
    }
}
