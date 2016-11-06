using TeamVesper.Repositories.Contracts;

namespace TeamVesper.UI.Contracts
{
    public interface IReporterFactory
    {
        IReporter<TEntity> GetJsonReporter<TEntity>();

        IReporter<TEntity> GetXmlReporter<TEntity>();

        IReporter<TEntity> GetPdfReporter<TEntity>();

        IReporter<TEntity> GetExcelReporter<TEntity>();
    }
}
