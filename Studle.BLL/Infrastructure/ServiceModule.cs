using Ninject.Modules;
using Studle.BLL.Interfaces;
using Studle.BLL.Services;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;
using Studle.DAL.Repositories;

namespace Studle.BLL.Infrastructure
{
    public sealed class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
            Bind<AppDbContext>().ToSelf().InSingletonScope().WithConstructorArgument(connectionString);

            Bind<IRepository<User>>().To<UserRepository>().InSingletonScope();
            Bind<IRepository<Mark>>().To<MarkRepository>().InSingletonScope();
            Bind<IRepository<Subject>>().To<SubjectRepository>().InSingletonScope();

            Bind<IHashService>().To<HashService>().InSingletonScope();
        }
    }
}
