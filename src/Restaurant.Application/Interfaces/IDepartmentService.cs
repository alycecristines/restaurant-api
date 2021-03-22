using Restaurant.Application.DTOs.Request;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        void Insert(DepartmentRequestDTO dto);
    }
}
