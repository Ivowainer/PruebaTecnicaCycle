using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaCycle.API.Config.ErrorHandler
{
    public interface IErrorHandler
    {
        ActionResult HandleError(Exception ex);
    }
}