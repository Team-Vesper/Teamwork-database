using System.Collections.Generic;
using TeamVesper.Mappers;
using TeamVesper.Models;

namespace TeamVesper.UI.Contracts
{
    public interface IMapperFactory
    {
        StarndartModelsToMongoModelMapper GetStarndartModelsToMongoModelMapper();

        BugToBugInfoMapper GetBugToBugInfoMapper();

        BugToBugReportMapper GetBugToBugReportMapper();

        DTOEducationToDbEducationMapper GetDTOEducationToDbEducationMapper();
    }
}
