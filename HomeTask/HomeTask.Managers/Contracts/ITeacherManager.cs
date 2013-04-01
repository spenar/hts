﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeTask.Models;

namespace HomeTask.Managers.Contracts
{
    public interface ITeacherManager
    {
        Teacher GetById(object ID);

        IQueryable<Teacher> GetAll(object insitutionID);

        IQueryable<Teacher> GetByGroup(object groupID);

        Teacher GetUserId(object ID);

        bool IsExist(object ID);

        void Add(Teacher teacher);

        void Update(Teacher teacher);

        void Delete(object ID);
    }
}
