using Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);
        CategoryDto Add(CreateCategoryRequestDto request);
        List<CategoryDto> GetAll();
        CategoryDto Update(UpdateCategoryRequestDto request);

        // void olmak zorunda değil. Farklı olsun diye bu şekilde yazıldı.
        void DeleteById(int id);


    }
}
