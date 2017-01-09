using IntelliTect.Coalesce.Controllers;
// Model Namespaces
using CoalesceStarter.Data;
    using CoalesceStarter.Data.Models;
using IntelliTect.Coalesce.Interfaces;

namespace CoalesceStarter.Web.Api
{
    // This class allows developers to inject base class behaviors into the inheritance chain
    // This file should not be modified, but another partial class should be created where your custom behavior can be placed.
    public partial class LocalBaseApiController<T, TDto> : BaseApiController<T, TDto, AppDbContext>
        where T : class, new()
        where TDto: class, IClassDto<T, TDto>, new()
    {
    }
}