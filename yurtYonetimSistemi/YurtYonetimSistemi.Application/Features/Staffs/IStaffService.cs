namespace YurtYonetimSistemi.Application.Features.Staffs;

public interface IStaffService
{
    Task<ServiceResult<StaffDto>> GetStaffByIdAsync(int id);
}
