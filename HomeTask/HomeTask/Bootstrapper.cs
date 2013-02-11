using System.Data.Entity;
using System.Web.Mvc;
using HomeTask.Core;
using HomeTask.Managers;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using HomeTask.Repository;

namespace HomeTask
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //Repositories
            container.RegisterType<IRepository<Teacher>, Repository<Teacher>>();
            container.RegisterType<IRepository<Task>, Repository<Task>>();
            container.RegisterType<IRepository<Student>, Repository<Student>>();
            container.RegisterType<IRepository<Group>, Repository<Group>>();
            container.RegisterType<IRepository<Group2Subject>, Repository<Group2Subject>>();
            container.RegisterType<IRepository<Group2Teacher>, Repository<Group2Teacher>>();
            container.RegisterType<IRepository<Institution>, Repository<Institution>>();
            container.RegisterType<IRepository<Institution2User>, Repository<Institution2User>>();
            container.RegisterType<IRepository<TypeOfTask>, Repository<TypeOfTask>>();
            container.RegisterType<IRepository<Subject>, Repository<Subject>>();
            container.RegisterType<IRepository<Teacher2Subject>, Repository<Teacher2Subject>>();

            //Managers
            container.RegisterType<ITaskManager, TaskManager>();
            container.RegisterType<IGroupManager, GroupManager>();
            container.RegisterType<ISubjectManager, SubjectManager>();
            container.RegisterType<ITeacherManager, TeacherManager>();
            container.RegisterType<IStudentManager, StudentManager>();
            container.RegisterType<ITypeOfTaskManager, TypeOfTaskManager>();
            container.RegisterType<IInstitutionManager, InstitutionManager>();

            //DbContext
            container.RegisterType<DbContext, HomeTaskContext>();
   

            return container;
        }
    }
}