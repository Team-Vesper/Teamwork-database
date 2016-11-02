using System.Collections.Generic;
using TeamVesper.Models;

namespace TeamVesper.ExportToXML.Contracts
{
    public interface IBugReportToXml
    {
        void XmlCreateReports(IEnumerable<BugReport> bugsReport);
    }
}
