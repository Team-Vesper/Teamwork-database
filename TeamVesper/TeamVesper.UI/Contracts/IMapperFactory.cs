using TeamVesper.Mappers;

namespace TeamVesper.UI.Contracts
{
    public interface IMapperFactory
    {
        StarndartModelsToMongoModelMapper GetStarndartModelsToMongoModelMapper();

        BugToBugInfoMapper GetBugToBugInfoMapper();

        BugToBugReportMapper GetBugToBugReportMapper();
    }
}
