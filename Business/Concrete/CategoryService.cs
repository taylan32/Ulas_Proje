using Azure.Core;
using Business.Abstract;
using Business.BusinessRules;
using Business.DTOs.CategoryDTOs;
using Business.Validators;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CategoryService(ICategoryRepository categoryRepository, 
            CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public CategoryDto Add(CreateCategoryRequestDto request)
        {
            // business rules
            // burada hatalı bir durum varsa business rules dan exception fırlatılır, aşağıdaki kodlar çalışmaz
            _categoryBusinessRules.CategoryNameCannotBeDuplicated(request.Name);

            // create category
            Category category = new() 
            { 
                Name = request.Name
            };

            // hatalı durum varsa exception fırlatılacak.
            CategoryValidator.Validate(category);

            // buraya kadar geldiyse bir sorun yoktur. db erişimi yapabilirsin.
            Category createdCategory = _categoryRepository.Add(category);

            // dbden aldığını direkt dönmek doğru değil. aynı değerler olsa bile dto yaz.
            // client tarafına gönderilmek istenmeyen bir field eklenirse kodu değiştirmek zorunda kalmazsın.
            return CategoryDto.Convert(createdCategory);
        }

        public void DeleteById(int id)
        {
            // kategori mevcut mu? kontrol et. Kategori dbde yoksa GetCategoryById exception fırlatacak. burada tekardan exception fırlatmaya gerek yok.
            Category category = GetCategoryById(id);
            _categoryRepository.Delete(category);
        }

        public List<CategoryDto> GetAll()
        {
            // bunun içine istersen filter veya include verebilirsin. alttaki örnek gibi
            // buraya pagination eklenebilir.
            List<Category> categories = _categoryRepository.GetList();

            return categories.Select(c => CategoryDto.Convert(c)).ToList();
        }

        public CategoryDto GetById(int id)
        {
            return CategoryDto.Convert(GetCategoryById(id));
        }

        public CategoryDto Update(UpdateCategoryRequestDto request)
        {
            // kategori mevcut mu? kontrol et. Kategori dbde yoksa GetCategoryById exception fırlatacak. burada tekardan exception fırlatmaya gerek yok.
            Category category = GetCategoryById(request.Id);

            //Request içinde bir sürü field içerebilir. Güncellemek istenmeyen alanlar null gelir.
            //if le kontrol et tüm alanları request içindeki null değilse request içindekiyle değiştir.
            // bunun için ayrı bir fonksiyon yazılabilir
            category.Name = request.Name;

            Category updatedCategory = _categoryRepository.Update(category);


            return CategoryDto.Convert(updatedCategory);
        }


        // bu kod parçası update ve delete için de kullanılacak.
        // package dışından erişimi kısıtlamak için protected yapıldı
        protected Category GetCategoryById(int id)
        {  
            // include kullanmak için örnek ilişkili olduğu entitileri çağırabilirsin
            //Category c = _categoryRepository.GetWithInclude(c => c.Id == id, include: c => c.Include(data => data.Product).Include(data => data.DigerEntity));

            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                throw new BusinessException("Requested category not found", 404);
            }
            return category;
        }

    }
}
