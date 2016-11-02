using System.Collections.Generic;

using TeamVesper.XmlDataReader.Models;

namespace TeamVesper.XmlDataReader.Contracts
{
    interface IXmlToDTOEducationConverter
    {
        IEnumerable<DTOEducation> GetAllDeveloppersEducations();
    }
}
