using Fireforce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fireforce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity, TService> : ControllerBase
        where TEntity : class
        where TService : IGenericService<TEntity>
    {
     //will do it tomorrow...
    }
}
