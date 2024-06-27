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
    public class UserBusiness
    {
        private readonly IRepository<User, int> _repository;
        private readonly IMapper _mapper;

        public UserBusiness(IRepository<User, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

      

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                var user = _repository.GetAll();
                var userList = _mapper.Map<List<UserModel>>(user);
                return userList;
            }
            catch (Exception)
            {

                throw new InternalServerErrorException("Cannot get all user");
            }
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
        public async Task<UserModel> GetUserByUsername(string username)
        {
            var user = _repository.FindByCondition(u => u.Username == username.Trim()).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
        public async Task<UpdateUserModel> UpdateUser(int id, UpdateUserModel model)
        {
            var userExist = await _repository.GetByIdAsync(id);
            if (userExist == null)
            {
                throw new NotFoundException("User not found");
            }
            userExist.DoB = model.DoB;
            userExist.Username = model.Username;
            userExist.Password = model.Password;
            userExist.Email = model.Email;
            userExist.Phone = model.Phone;
            userExist.Fullname = model.Fullname;
            userExist.Address = model.Address;
            userExist.UpdatedAt = DateTime.UtcNow;
            _repository.Update(userExist);
            await _repository.Commit();
            return model;
        }
        public async Task<bool> ChangeStatusUser(int id, string status)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            user.Status = status;
            _repository.Update(user);
            var result = await _repository.Commit();
            return result > 0;
        }
    }
}
