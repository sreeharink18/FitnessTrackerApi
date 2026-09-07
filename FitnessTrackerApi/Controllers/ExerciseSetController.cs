using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model.Dto.WorkoutDtoFolder;
using FitnessTrackerApi.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FitnessTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseSetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExerciseSetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("getExerciseSetById/{id}")]
        public async Task<IActionResult> GetExerciseSetById(Guid id)
        {
            try
            {
                var exerciseSet = await _unitOfWork.ExerciseSetRepository.GetAsync(w => w.Id == id);
                if (exerciseSet == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Exercise set not found"));
                }

                return Ok(ApiResponseHelper.SuccessResponse(exerciseSet));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error fetching exercise set: {ex.Message}"));
            }
        }
        [HttpGet("getAllExerciseSetsAndWorkoutSessionsByDay/{day}")]
        public async Task<IActionResult> GetAllExerciseSetsAndWorkoutSessionsByDay(DateTime day, string userId)
        {
            try
            {
                var workoutSessionsDay = await _unitOfWork.WorkoutSessionDayRepository.GetAsync(x => x.WorkoutDate == day && x.UserId == userId);
                if (workoutSessionsDay == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Workout session day not found", HttpStatusCode.NotFound));
                }
                var exerciseSets = await _unitOfWork.ExerciseSetRepository.GetAllAsync(x => x.WorkoutSessionDayId == workoutSessionsDay.Id);
                return Ok(ApiResponseHelper.SuccessResponse(exerciseSets));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error fetching exercise sets and workout sessions: {ex.Message}"));
            }
        }
        [HttpPost("createExerciseSet")]
        public async Task<IActionResult> CreateExerciseSet([FromBody] List<CreateRequestExerciseSetDto> exerciseSet)
        {
            try
            {
                foreach (var set in exerciseSet)
                {
                    var newExerciseSet = new Model.ExerciseSet
                    {
                        WorkoutSessionDayId = set.WorkoutSessionDayId,
                        ExerciseId = set.ExerciseId,
                        SetNumber = set.SetNumber,
                        Weight = set.Weight,
                        Reps = set.Reps,
                        Duration = set.Duration,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.ExerciseSetRepository.AddAsync(newExerciseSet);
                }
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(exerciseSet));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error creating exercise set: {ex.Message}"));
            }
        }
        [HttpPut("updateExerciseSet/{id}")]
        public async Task<IActionResult> UpdateExerciseSet(Guid id, [FromBody] UpdateRequestExerciseSetDto exerciseSet)
        {
            try
            {
                var existingExerciseSet = await _unitOfWork.ExerciseSetRepository.GetAsync(e => e.Id == id);
                if (existingExerciseSet == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Exercise set not found"));
                }
                existingExerciseSet.ExerciseId = exerciseSet.ExerciseId;
                existingExerciseSet.SetNumber = exerciseSet.SetNumber;
                existingExerciseSet.Weight = exerciseSet.Weight;
                existingExerciseSet.Reps = exerciseSet.Reps;
                existingExerciseSet.Duration = exerciseSet.Duration;

                await _unitOfWork.ExerciseSetRepository.UpdateAsync(existingExerciseSet);
                await _unitOfWork.Save();

                return Ok(ApiResponseHelper.SuccessResponse(existingExerciseSet));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error updating exercise set: {ex.Message}"));
            }
        }
        [HttpDelete("deleteExerciseSet/{id}")]
        public async Task<IActionResult> DeleteExerciseSet(Guid id)
        {
            try
            {
                var existingExerciseSet = await _unitOfWork.ExerciseSetRepository.GetAsync(e => e.Id == id);
                if (existingExerciseSet == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Exercise set not found"));
                }

                await _unitOfWork.ExerciseSetRepository.RemoveAsync(existingExerciseSet);
                await _unitOfWork.Save();

                return Ok(ApiResponseHelper.SuccessResponse("Exercise set deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error deleting exercise set: {ex.Message}"));
            }
        }
    }
}
