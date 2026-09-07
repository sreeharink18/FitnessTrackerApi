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
    public class WorkoutAreaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkoutAreaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("getAllWorkoutAreas")]
        public async Task<IActionResult> GetAllWorkoutAreas()
        {
            try
            {
                var workoutAreas = await _unitOfWork.WorkoutAreaRepository.GetAllAsync();
                return Ok(workoutAreas);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving workout areas: {ex.Message}"));
            }
        }
        [HttpGet("getWorkoutAreaById/{id}")]
        public async Task<IActionResult> GetWorkoutAreaById(Guid id)
        {
            try
            {
                var workoutArea = await _unitOfWork.WorkoutAreaRepository.GetAsync(w => w.Id == id);
                if (workoutArea == null)
                {
                    return NotFound($"Workout area with ID {id} not found.");
                }
                return Ok(ApiResponseHelper.SuccessResponse(workoutArea));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving workout area: {ex.Message}"));
            }
        }
        [HttpPost("createWorkoutArea")]
        public async Task<IActionResult> CreateWorkoutArea([FromBody] CreateRequestWorkoutAreaDto createRequest)
        {
            try
            {
                var workoutArea = new WorkoutArea
                {
                    UserId = createRequest.UserId,
                    Name = createRequest.Name,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                await _unitOfWork.WorkoutAreaRepository.AddAsync(workoutArea);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(new { id = workoutArea.Id, workoutArea }, HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error creating workout area: {ex.Message}"));
            }
        }
        [HttpPut("updateWorkoutArea/{id}")]
        public async Task<IActionResult> UpdateWorkoutArea(Guid id, [FromBody] WorkoutArea workoutArea)
        {
            try
            {
                if (id != workoutArea.Id)
                {
                    return BadRequest("ID mismatch.");
                }
                var existingWorkoutArea = await _unitOfWork.WorkoutAreaRepository.GetAsync(w => w.Id == id);
                if (existingWorkoutArea == null)
                {
                    return NotFound($"Workout area with ID {id} not found.");
                }
                existingWorkoutArea.Name = workoutArea.Name;
                existingWorkoutArea.UpdatedAt = DateTime.UtcNow;
                existingWorkoutArea.IsActive = workoutArea.IsActive;
                existingWorkoutArea.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.WorkoutAreaRepository.UpdateAsync(existingWorkoutArea);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(existingWorkoutArea, HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error updating workout area: {ex.Message}"));
            }
        }
        [HttpDelete("deleteWorkoutArea/{id}")]
        public async Task<IActionResult> DeleteWorkoutArea(Guid id)
        {
            try
            {
                var workoutArea = await _unitOfWork.WorkoutAreaRepository.GetAsync(w => w.Id == id);
                if (workoutArea == null)
                {
                    return NotFound($"Workout area with ID {id} not found.");
                }
                await _unitOfWork.WorkoutAreaRepository.RemoveAsync(workoutArea);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse("This workout area has been deleted.", HttpStatusCode.NoContent));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error deleting workout area: {ex.Message}"));
            }
        }
    }
}
