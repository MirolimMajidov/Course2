using CRUDOperationWithElasticSearch.Models;
using CRUDOperationWithElasticSearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationWithElasticSearch.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController<User>
    {
        public UserController(ILogger<UserController> logger, IEntityRepository<User> repository) : base(logger, repository) { }
    }
}