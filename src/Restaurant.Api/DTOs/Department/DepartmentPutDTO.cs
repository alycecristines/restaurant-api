using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Department
{
    [ModelMetadataType(typeof(Entity.Department))]
    public class DepartmentPutDTO : PutDTO
    {
        public string Description { get; set; }
    }
}
