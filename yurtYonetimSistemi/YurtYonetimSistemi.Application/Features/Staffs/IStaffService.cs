using YurtYonetimSistemi.Application.Features.Staffs.Create;
using YurtYonetimSistemi.Application.Features.Users.Create;

namespace YurtYonetimSistemi.Application.Features.Staffs;

public interface IStaffService
{
    Task<ServiceResult<StaffDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateStaffResponse>> CreateAsync(CreateStaffRequest request, CreateUserRequest requestUser);
}
