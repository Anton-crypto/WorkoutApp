using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Core.IConfiguration;
using WorkoutApi.Models;

namespace WorkoutApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly ILogger<WorkoutsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutsController(ILogger<WorkoutsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var workout = await _unitOfWork.Workouts.GetAsync(id);

            if (workout == null)
                return NotFound();

            return Ok(workout);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Workouts.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateExerciseAsync(Workout workout)
        {
            if(ModelState.IsValid)
            {
                workout.Id = Guid.NewGuid();

                await _unitOfWork.Workouts.AddAsync(workout);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("CreateExercise", new { workout.Id }, workout);
            }

            return new JsonResult("Ошибка сервера") { StatusCode = 500 };
        }
        [HttpPost]
        [Route("musclesgroup")]
        public async Task<IActionResult> CreateMusclesGroupAsync(MusclesGroup musclesGroup)
        {
            if (ModelState.IsValid)
            {
                musclesGroup.Id = Guid.NewGuid();

                await _unitOfWork.MusclesGroups.AddAsync(musclesGroup);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("CreateWorkout", new { musclesGroup.Id }, musclesGroup);
            }

            return new JsonResult("Ошибка сервера.") { StatusCode = 500 };
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("vidio")]
        public async Task<IActionResult> Post()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();

                var fileList = formCollection.Files.ToList();
                var keysList = formCollection.Keys.ToList();

                var folderName = System.IO.Path.Combine("Resources", "Vidios");
                var pathToSave = System.IO.Path.Combine(Directory.GetCurrentDirectory(), folderName);

                foreach (var item in fileList)
                {
                    if (item.Length <= 0)
                    {
                        break;
                    }

                    var fileName = Guid.NewGuid().ToString() + "." + item.ContentType.Trim('"').Split('/')[1];

                    var fullPath = System.IO.Path.Combine(pathToSave, fileName);
                    var dbPath = System.IO.Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        item.CopyTo(stream); 
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}

