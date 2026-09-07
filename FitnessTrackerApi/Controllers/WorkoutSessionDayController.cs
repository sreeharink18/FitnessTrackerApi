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
    public class WorkoutSessionDayController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkoutSessionDayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetWorkoutSessionDays/{id}")]
        public async Task<IActionResult> GetWorkoutSessionDays(Guid id)
        {
            try
            {
                var workoutSessionDays = await _unitOfWork.WorkoutSessionDayRepository.GetAllAsync(w => w.Id == id);
                return Ok(ApiResponseHelper.SuccessResponse(workoutSessionDays));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving workout session days: {ex.Message}"));
            }
        }
        [HttpPost("CreateWorkoutSessionDay")]
        public async Task<IActionResult> CreateWorkoutSessionDay([FromBody] CreateRequestWorkoutSessionDayDto model)
        {
            try
            {
                var workoutSessionDay = new WorkoutSessionDay
                {
                    UserId = model.UserId,
                    StartedAt = model.StartedAt,
                    EndedAt = model.EndedAt,
                    WorkoutDate = model.WorkoutDate,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.WorkoutSessionDayRepository.AddAsync(workoutSessionDay);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(workoutSessionDay, HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error creating workout session day: {ex.Message}"));
            }
        }
        [HttpPut("UpdateWorkoutSessionDay/{id}")]
        public async Task<IActionResult> UpdateWorkoutSessionDay(Guid id, [FromBody] UpdateRequestWorkoutSessionDayDto model)
        {
            try
            {
                var workoutSessionDay = await _unitOfWork.WorkoutSessionDayRepository.GetAsync(w => w.Id == id);
                if (workoutSessionDay == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Workout session day not found"));
                }

                workoutSessionDay.WorkoutDate = model.WorkoutDate;
                workoutSessionDay.StartedAt = model.StartedAt;
                workoutSessionDay.EndedAt = model.EndedAt;

                await _unitOfWork.WorkoutSessionDayRepository.UpdateAsync(workoutSessionDay);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(workoutSessionDay));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error updating workout session day: {ex.Message}"));
            }
        }
        [HttpDelete("DeleteWorkoutSessionDay/{id}")]
        public async Task<IActionResult> DeleteWorkoutSessionDay(Guid id)
        {
            try
            {
                var workoutSessionDay = await _unitOfWork.WorkoutSessionDayRepository.GetAsync(w => w.Id == id);
                if (workoutSessionDay == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse("Workout session day not found"));
                }

                await _unitOfWork.WorkoutSessionDayRepository.RemoveAsync(workoutSessionDay);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(workoutSessionDay));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error deleting workout session day: {ex.Message}"));
            }
        }
    }
}
