using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Department
{
    [ModelMetadataType(typeof(Entity.Department))]
    public class DepartmentUpdateModel : UpdateModel
    {
        public string Description { get; set; }
    }
}
