using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Core.IConfiguration;
using WorkoutApi.Models;
using WorkoutApi.Models.ViewModels;
using WorkoutApi.Models.WorkoutModels;

namespace WorkoutApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExercisesControllers : ControllerBase
    {
        private readonly ILogger<WorkoutsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ExercisesControllers(ILogger<WorkoutsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Exercises.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateExercisAsync(ExercisView exercisView)
        {
            if (ModelState.IsValid)
            {
                Exercis exercis = new Exercis()
                {
                    Id = Guid.NewGuid(),
                    Name = exercisView.Name,
                    CountSets = exercisView.CountSets,
                    TimeOfRelax = exercisView.TimeOfRelax,
                    NumberOfRepetitions = exercisView.NumberOfRepetitions
                };

                await _unitOfWork.Exercises.AddAsync(exercis);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("CreateExercise", new { exercis.Id }, exercis);
            }

            return new JsonResult("Ошибка сервера") { StatusCode = 500 };
        }
    }
}


