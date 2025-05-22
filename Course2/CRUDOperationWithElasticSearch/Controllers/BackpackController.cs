using CRUDOperationWithElasticSearch.Models;
using CRUDOperationWithElasticSearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationWithElasticSearch.Controllers
{
    [Route("[controller]")]
    public class BackpackController : BaseController<Backpack>
    {
        public BackpackController(ILogger<BackpackController> logger, IEntityRepository<Backpack> repository) : base(logger, repository) { }
    }
}