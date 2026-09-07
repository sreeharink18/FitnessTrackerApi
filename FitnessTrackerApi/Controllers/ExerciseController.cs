using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;
using FitnessTrackerApi.Model.Dto.WorkoutDtoFolder;
using FitnessTrackerApi.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FitnessTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExerciseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("getAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            try
            {
                var exercises = await _unitOfWork.ExerciseRepository.GetAllAsync();
                return Ok(ApiResponseHelper.SuccessResponse(exercises));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving exercises: {ex.Message}"));
            }
        }
        [HttpGet("getExerciseById/{id}")]
        public async Task<IActionResult> GetExerciseById(Guid id)
        {
            try
            {
                var exercise = await _unitOfWork.ExerciseRepository.GetAsync(e => e.Id == id);
                if (exercise == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Exercise with ID {id} not found.", HttpStatusCode.NotFound));
                }
                return Ok(ApiResponseHelper.SuccessResponse(exercise));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving exercise: {ex.Message}"));
            }
        }
        [HttpPost("createExercise")]
        public async Task<IActionResult> CreateExercise([FromBody] CreateRequestExerciseDto model)
        {
            try
            {
                var exercise = new Exercise
                {
                    WorkoutPartId = model.WorkoutPartId,
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _unitOfWork.ExerciseRepository.AddAsync(exercise);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(exercise, HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error creating exercise: {ex.Message}"));
            }
        }
        [HttpPut("updateExercise/{id}")]
        public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] UpdateRequestExerciseDto model)
        {
            try
            {
                var exercise = await _unitOfWork.ExerciseRepository.GetAsync(e => e.Id == id);
                if (exercise == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Exercise with ID {id} not found.", HttpStatusCode.NotFound));
                }
                exercise.WorkoutPartId = model.WorkoutPartId;
                exercise.Name = model.Name;
                exercise.Description = model.Description;
                exercise.UpdatedAt = DateTime.UtcNow;
                exercise.IsActive = model.IsActive;
                await _unitOfWork.ExerciseRepository.UpdateAsync(exercise);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(exercise, HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error updating exercise: {ex.Message}"));
            }
        }
        [HttpDelete("deleteExercise/{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            try
            {
                var exercise = await _unitOfWork.ExerciseRepository.GetAsync(e => e.Id == id);
                if (exercise == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Exercise with ID {id} not found.", HttpStatusCode.NotFound));
                }
                await _unitOfWork.ExerciseRepository.RemoveAsync(exercise);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(exercise, HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error deleting exercise: {ex.Message}"));
            }
        }
    }
}
