using TeamVesper.Repositories.Contracts;

namespace TeamVesper.UI.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetSqlServerUnitOFWork();

        IUnitOfWork GetMySqlUnitOfWork();
    }
}
