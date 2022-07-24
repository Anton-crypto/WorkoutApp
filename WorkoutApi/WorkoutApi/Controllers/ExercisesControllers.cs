using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkoutApi.Core.IConfiguration;
using WorkoutApi.Manager;
using WorkoutApi.Manager.FileManager;
using WorkoutApi.Models;
using WorkoutApi.Models.ViewModels;
using WorkoutApi.Models.WorkoutModels;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly ILogger<WorkoutsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IFileManager<IFormCollection> _fileManager;

        public ExercisesController(ILogger<WorkoutsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fileManager = new FileManager();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Exercises.GetAllAsync());
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> CreateExercisAsync()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();

                var fileList = formCollection.Files.ToList();
                var keyList = formCollection.Keys.ToList();

                ExercisView exercisView = new ExercisView()
                {
                    Files = formCollection.Files.ToList(),
                };

                foreach (var key in keyList)
                {
                    switch (key)
                    {
                        case "DifficultyLevelId": 
                            exercisView.DifficultyLevelId = Guid.Parse(formCollection[key]); break;
                        case "MusclesGroupId":
                            exercisView.MusclesGroupId = Guid.Parse(formCollection[key]); break;
                        case "Name":
                            exercisView.Name = formCollection[key]; break;
                        case "CountSets":
                            exercisView.CountSets = formCollection[key]; break;
                        case "TimeOfRelax":
                            exercisView.TimeOfRelax = formCollection[key]; break;
                        case "NumberOfRepetitions":
                            exercisView.NumberOfRepetitions = formCollection[key]; break;
                        default: break;
                    }
                }

                return Ok(exercisView);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            //if (ModelState.IsValid)
            //{
            //    Exercis exercis = new Exercis()
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = exercisView.Name,
            //        CountSets = exercisView.CountSets,
            //        TimeOfRelax = exercisView.TimeOfRelax,
            //        NumberOfRepetitions = exercisView.NumberOfRepetitions
            //    };

            //    //await _unitOfWork.Exercises.AddAsync(exercis);
            //    //await _unitOfWork.CompleteAsync();

            //    var formCollection = await Request.ReadFormAsync();
            //    var fileList = formCollection.Files.ToList();

            //    //var result = _fileManager.Save(await Request.ReadFormAsync());
            //    //var listFile = new List<Models.File>();

            //    //foreach (var item in result)
            //    //{
            //    //    Models.File file = new Models.File()
            //    //    {
            //    //        Id = Guid.NewGuid(),
            //    //        Type = "",
            //    //        Url = "",
            //    //    };

            //    //    listFile.Add(file);
            //    //}

            //    //Debug.Write(result);

            //    return CreatedAtAction("CreateExercise", new { exercis.Id }, exercis);
            //}

            return new JsonResult("Ошибка сервера") { StatusCode = 500 };
        }
    }
}