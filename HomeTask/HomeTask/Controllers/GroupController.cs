using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTask.Core.Mappers;
using HomeTask.Core.ViewModels;
using HomeTask.Managers.Contracts;

namespace HomeTask.Controllers
{

    public class GroupController : Controller
    {
        private readonly IGroupManager _groupManager;

        public GroupController(IGroupManager groupManager)
        {
            this._groupManager = groupManager;
        }

        public ActionResult GetGroups(ulong institutionID)
        {
            var groups = this._groupManager.GetAll(institutionID).Select(GroupMapper.ToViewModelExpression);

            return this.Json(groups);
        }



    }
}
