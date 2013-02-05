using HomeTask.Managers;
using HomeTask.Managers.Contracts;
using HomeTask.Models;
using HomeTask.Repository.Contracts;

[assembly: WebActivator.PreApplicationStartMethod(typeof(HomeTask.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(HomeTask.App_Start.NinjectWebCommon), "Stop")]

namespace HomeTask.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using HomeTask.Repository;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Repositories
            kernel.Bind<IRepository<Teacher>>().To<Repository<Teacher>>();
            kernel.Bind<IRepository<Task>>().To<Repository<Task>>();
            kernel.Bind<IRepository<Student>>().To<Repository<Student>>();
            kernel.Bind<IRepository<Group>>().To<Repository<Group>>();
            kernel.Bind<IRepository<Group2Subject>>().To<Repository<Group2Subject>>();
            kernel.Bind<IRepository<Group2Teacher>>().To<Repository<Group2Teacher>>();
            kernel.Bind<IRepository<Institution>>().To<Repository<Institution>>();
            kernel.Bind<IRepository<Institution2User>>().To<Repository<Institution2User>>();
            kernel.Bind<IRepository<TypeOfTask>>().To<Repository<TypeOfTask>>();
            kernel.Bind<IRepository<Subject>>().To<Repository<Subject>>();

            //Managers
            kernel.Bind<ITaskManager>().To<TaskManager>();
            kernel.Bind<IGroupManager>().To<GroupManager>();
            kernel.Bind<ISubjectManager>().To<SubjectManager>();
            kernel.Bind<ITeacherManager>().To<TeacherManager>();
            kernel.Bind<IStudentManager>().To<StudentManager>();
            kernel.Bind<ITypeOfTaskManager>().To<TypeOfTaskManager>();
        }
    }
}
