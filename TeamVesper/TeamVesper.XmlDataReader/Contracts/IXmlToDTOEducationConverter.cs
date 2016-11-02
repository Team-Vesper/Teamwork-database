using System.Collections.Generic;

using TeamVesper.XmlDataReader.Models;

namespace TeamVesper.XmlDataReader.Contracts
{
    public interface IXmlToDTOEducationConverter
    {
        IEnumerable<DTOEducation> GetAllDeveloppersEducations();
    }
}
