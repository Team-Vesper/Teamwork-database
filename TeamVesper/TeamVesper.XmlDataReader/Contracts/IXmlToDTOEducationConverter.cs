using System.Collections.Generic;
using TeamVesper.Models;

namespace TeamVesper.XmlDataReader.Contracts
{
    public interface IXmlToDTOEducationConverter
    {
        IEnumerable<DTOEducation> GetAllDeveloppersEducations();
    }
}
