using System.Net;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Application.Contracts.Persistence;


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

    //public async Task<ServiceResult<CreateStaffResponse>> CreateAsync(CreateStaffRequest request)
    //{
        


    //    //var staff = new Staff()
    //    //{
            

    //    //};

    //    //await roomRepository.AddAsync(room);
    //    //await unitOfWork.SaveChangesAsync();

    //    //return ServiceResult<CreateRoomResponse>.Success(new CreateRoomResponse(room.Id));
    //}


}
