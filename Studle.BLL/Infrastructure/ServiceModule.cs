using Ninject.Modules;
using Studle.BLL.Interfaces;
using Studle.BLL.Services;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;
using Studle.DAL.Repositories;

namespace Studle.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connection) : base()
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
            Bind<AppDbContext>().ToSelf().InSingletonScope().WithConstructorArgument(_connectionString);

            Bind<IRepository<User>>().To<UserRepository>().InSingletonScope();
            Bind<IRepository<Mark>>().To<MarkRepository>().InSingletonScope();
            Bind<IRepository<Subject>>().To<SubjectRepository>().InSingletonScope();

            // Bind<IUserService>().To<UserService>().InSingletonScope();
            // Bind<IMarkService>().To<MarkService>().InSingletonScope();
            // Bind<ISubjectService>().To<SubjectService>().InSingletonScope();
            Bind<IHashService>().To<HashService>().InSingletonScope();
        }
    }
}