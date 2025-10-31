using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.StudentLeaves.Create;
using YurtYonetimSistemi.Application.Features.Users;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public class StudentLeaveService(IStudentLeaveRepository studentLeaveRepository,IUnitOfWork unitOfWork,IUserService userService):IStudentLeaveService
{

    public async Task<ServiceResult<StudentLeaveDto>> GetByIdAsync(int id)
    {
        var studentLeave = await studentLeaveRepository.GetByIdAsync(id);
        // Check if staff exists
        if (studentLeave is null)
        {
            return ServiceResult<StudentLeaveDto>.Fail("StudentLeave not found", HttpStatusCode.NotFound);
        }
        var fullName = await userService.GetFullNameByUserIdAsync(studentLeave.Student.UserId);
        var studentLeaveDto = new StudentLeaveDto(
            Id:studentLeave.Id,
            StudentId:studentLeave.StudentId,
            StartDate:studentLeave.StartDate,
            EndDate:studentLeave.EndDate,
            Reason:studentLeave.Reason,
            Status:studentLeave.Status,
            RequestDate:studentLeave.RequestDate,
            StudentName:fullName!
        );
        return ServiceResult<StudentLeaveDto>.Success(studentLeaveDto);
    }

    public async Task<ServiceResult<CreateStudentLeaveResponse>> CreateAsync(CreateStudentLeaveRequest request)
    {
        var anyStudentLeave = await studentLeaveRepository.AnyActiveLeaveByStudentIdAsync(request.StudentId);

        if (anyStudentLeave)
            return ServiceResult<CreateStudentLeaveResponse>.Fail(
                "Student already has an active leave or pending leave request.",
                HttpStatusCode.BadRequest);

        if (request.StartDate >= request.EndDate)
            return ServiceResult<CreateStudentLeaveResponse>.Fail(
                "Start date cannot be later than or equal to end date.",
                HttpStatusCode.BadRequest);

        var studentLeave = new StudentLeave
        {
            StudentId = request.StudentId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Reason = request.Reason,
            Status = LeaveStatus.Pending,
            RequestDate = DateTime.UtcNow
        };

        await studentLeaveRepository.AddAsync(studentLeave);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateStudentLeaveResponse>.Success(
            new CreateStudentLeaveResponse(studentLeave.Id));
    }

}
