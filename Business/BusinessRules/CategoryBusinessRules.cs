using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CategoryNameCannotBeDuplicated(string name) 
        {
            Category category = _categoryRepository.Get(c => c.Name == name);
            if(category != null)
            {
                throw new BusinessException("This category already exists", 400);
            }
        }


    }
}
