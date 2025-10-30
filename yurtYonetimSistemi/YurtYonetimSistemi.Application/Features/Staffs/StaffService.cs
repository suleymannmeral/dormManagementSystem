using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Staffs.Create;
using YurtYonetimSistemi.Application.Features.Users;
using YurtYonetimSistemi.Application.Features.Users.Create;
using YurtYonetimSistemi.Domain.Entities;


namespace YurtYonetimSistemi.Application.Features.Staffs;

public class StaffService(IStaffRepository staffRepository,
    IUnitOfWork unitOfWork,
    IUserService userService):IStaffService
{
    public async Task<ServiceResult<StaffDto>> GetStaffByIdAsync(int id)
    {
        var staff = await staffRepository.GetByIdAsync(id);
        // Check if staff exists
        if (staff is null)
        {
            return ServiceResult<StaffDto>.Fail("Staff not found",HttpStatusCode.NotFound);
        }
        var fullName = await userService.GetFullNameByUserIdAsync(staff.UserId);
        var staffDto = new StaffDto(
            staff.Id,
            fullName!,
            staff.Position,
            staff.UserId
        );
        return ServiceResult<StaffDto>.Success(staffDto);
    }

    public async Task<ServiceResult<CreateStaffResponse>> CreateAsync(CreateStaffRequest request,CreateUserRequest requestUser)
    {
        
        var userResult = await userService.CreateUserAsync(requestUser);
        //if (!userResult.Success)
        //    return ServiceResult<CreateUserResponse>.Fail(userResult.ErrorMessage);

        var staff = new Staff()
        {
            Position=request.Position,
            UserId=userResult.Data!.UserId
        };

        await staffRepository.AddAsync(staff);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateStaffResponse>.Success(new CreateStaffResponse(staff.Id));
    }


}
