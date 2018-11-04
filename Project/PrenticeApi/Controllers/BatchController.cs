using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PrenticeApi.Dtos;
using PrenticeApi.Helpers;
using PrenticeApi.Services;

namespace PrenticeApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private IBatchService _service;

        public BatchController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IBatchService service)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _service = service;
        }
        
        [HttpPost("Create")]
        public async Task InitiateBatch(BatchDto batchDto)
        {
            var activeUser = HttpContext.User;
            await _service.InitiateBatchAsync(batchDto, activeUser);
        }

        [HttpPost("RoutineCreate")]
        public async Task InitiateRoutine(BatchDto batchDto)
        {
            var activeUser = HttpContext.User;
            await _service.InitiateBatchAsync(batchDto, activeUser);
        }
    }
}