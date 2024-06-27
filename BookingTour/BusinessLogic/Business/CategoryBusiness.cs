using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business
{
    public class CategoryBusiness
    {
        private readonly IRepository<CategoryTour, int> _repository;
        private readonly IMapper _mapper;

        public CategoryBusiness(IRepository<CategoryTour, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            var cate = _repository.GetAll();
            var cateList = _mapper.Map<List<CategoryModel>>(cate);
            return cateList;
        }
        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var cate = await _repository.GetByIdAsync(id);
            if (cate == null)
            {
                throw new NotFoundException("Category not found");
            }
            var cg = _mapper.Map<CategoryModel>(cate);
            return cg;
        }
        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            var cate = await _repository.FindByCondition(c => c.Name == name.Trim()).FirstOrDefaultAsync();
            if (cate == null)
            {
                throw new NotFoundException("Category not found");
            }
            var cg = _mapper.Map<CategoryModel>(cate);
            return cg;

        }
        public async Task<bool> CreateCategory(CreateCategoryModel createCategory,int adminId)
        {
            var cateExist = await _repository.GetAll().Where(c => c.Name == createCategory.Name.Trim()).FirstOrDefaultAsync();
            if (cateExist != null)
            {
                throw new BadRequestException("Category has exist");
            }
            var newCate = new CategoryTour
            {
                ModifyBy = adminId,
                CreaateBy = adminId,
                Name = createCategory.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = SD.ACTIVE
            };
            
            await _repository.AddAsync(newCate);
            var result = await _repository.Commit();
            return result > 0;

        }
        public async Task<bool> UpdateCategory(int id,UpdateCategoryModel updateCategory,int modifyBy)
        {
            var cate = await _repository.FindByCondition(c => c.Id == id).FirstOrDefaultAsync();
            if(cate == null)
            {
                throw new NotFoundException("Category not found");
            }
            cate.ModifyBy = modifyBy;
            cate.Name = updateCategory.Name;
            cate.UpdatedAt = DateTime.UtcNow;
            await _repository.AddAsync(cate);
            var result = await _repository.Commit();
            return result > 0;
        }
        public async Task<bool> ChangeStatusCate(int id, string status,int modifyBy)
        {
            var cate = await _repository.GetByIdAsync(id);
            if(cate == null)
            {
                throw new NotFoundException("Category not found");
            }
            cate.ModifyBy = modifyBy;
            cate.UpdatedAt = DateTime.UtcNow;
            cate.Status = status;
             _repository.Update(cate);
            var result = await _repository.Commit();  
            return result > 0;
        }
    }
    
}
