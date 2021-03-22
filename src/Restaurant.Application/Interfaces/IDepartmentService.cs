using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentResponseDTO Insert(DepartmentRequestDTO dto);
    }
}
