namespace TeamVesper.UI.Contracts
{
    public interface IFormFactory
    {
        CreateDBForm GetCreateDbForm();

        ImportForm GetImportForm();

        TransferForm GetTransferForm();

        ExportForm GetExportForm();
    }
}
