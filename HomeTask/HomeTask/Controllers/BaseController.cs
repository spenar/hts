using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Helpers;
using HomeTask.Managers.Contracts;

namespace HomeTask.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentUserName
        {
            get { return User.Identity.Name; }
        }

        protected Guid CurrentUserID
        {
            get { return (Guid)this.HttpContext.Cache.GetUserID(); }
        }

        public BaseController()
        {
            var ID = WebSecurity.GetUser(CurrentUserName).ProviderUserKey;
            this.HttpContext.Cache.SetUserID(ID is Guid ? (Guid)ID : Guid.Empty);
        }
    }
}