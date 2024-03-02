using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static CategoryDto Convert(Category from)
        {
            return new() 
            {
                Id = from.Id,
                Name = from.Name,
            };
        }
    }
}
