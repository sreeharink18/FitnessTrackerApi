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
    public class WorkoutPartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkoutPartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("getAllWorkoutParts")]
        public async Task<IActionResult> GetAllWorkoutParts()
        {
            try
            {
                var workoutParts = await _unitOfWork.WorkoutPartRepository.GetAllAsync();
                return Ok(ApiResponseHelper.SuccessResponse(workoutParts));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving workout parts: {ex.Message}"));
            }
        }
        [HttpGet("getWorkoutPartById/{id}")]
        public async Task<IActionResult> GetWorkoutPartById(Guid id)
        {
            try
            {
                var workoutPart = await _unitOfWork.WorkoutPartRepository.GetAsync(w => w.Id == id);
                if (workoutPart == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Workout part with ID {id} not found.", HttpStatusCode.NotFound));
                }
                return Ok(ApiResponseHelper.SuccessResponse(workoutPart));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error retrieving workout part: {ex.Message}"));
            }
        }
        [HttpPost("createWorkoutPart")]
        public async Task<IActionResult> CreateWorkoutPart([FromBody] CreateRequestWorkoutPartDto createRequest)
        {
            try
            {
                var workoutPart = new WorkoutPart
                {
                    WorkoutAreaId = createRequest.WorkoutAreaId,
                    ParentPartId = createRequest.ParentPartId,
                    Name = createRequest.Name,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                await _unitOfWork.WorkoutPartRepository.AddAsync(workoutPart);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(new { id = workoutPart.Id, workoutPart }, HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error creating workout part: {ex.Message}"));
            }
        }
        [HttpPut("updateWorkoutPart/{id}")]
        public async Task<IActionResult> UpdateWorkoutPart(Guid id, [FromBody] UpdateRequestWorkoutPartDto workoutPart)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ApiResponseHelper.ErrorResponse("ID is missed.", HttpStatusCode.BadRequest));
                }
                var existingWorkoutPart = await _unitOfWork.WorkoutPartRepository.GetAsync(w => w.Id == id);
                if (existingWorkoutPart == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Workout part with ID {id} not found.", HttpStatusCode.NotFound));
                }
                existingWorkoutPart.ParentPartId = workoutPart.ParentPartId;
                existingWorkoutPart.Name = workoutPart.Name;
                existingWorkoutPart.UpdatedAt = DateTime.UtcNow;
                existingWorkoutPart.IsActive = workoutPart.IsActive;
                await _unitOfWork.WorkoutPartRepository.UpdateAsync(existingWorkoutPart);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse(existingWorkoutPart, HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error updating workout part: {ex.Message}"));
            }
        }
        [HttpDelete("deleteWorkoutPart/{id}")]
        public async Task<IActionResult> DeleteWorkoutPart(Guid id)
        {
            try
            {
                var existingWorkoutPart = await _unitOfWork.WorkoutPartRepository.GetAsync(w => w.Id == id);
                if (existingWorkoutPart == null)
                {
                    return NotFound(ApiResponseHelper.ErrorResponse($"Workout part with ID {id} not found.", HttpStatusCode.NotFound));
                }
                await _unitOfWork.WorkoutPartRepository.RemoveAsync(existingWorkoutPart);
                await _unitOfWork.Save();
                return Ok(ApiResponseHelper.SuccessResponse($"Workout part with ID {id} deleted successfully.", HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseHelper.ErrorResponse($"Error deleting workout part: {ex.Message}"));
            }
        }
    }
}
