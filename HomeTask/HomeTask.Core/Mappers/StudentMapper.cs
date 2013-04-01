using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HomeTask.Core.ViewModels;
using HomeTask.Models;

namespace HomeTask.Core.Mappers
{
    public static class StudentMapper
    {
        public static Expression<Func<Student, StudentViewModel>> ToViewModelExpression = student =>
                                                                                          new StudentViewModel()
                                                                                              {
                                                                                                  ID = student.Id,
                                                                                                  Group = student.Group.Name,
                                                                                                  IsConfirmed = student.IsConfirmed,
                                                                                                  Name = student.Name,
                                                                                                  Surname = student.Surname
                                                                                              };
    }
}
