using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using DomainLayer.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _imapper;

        public UserService(IUnitOfWork unitOfWork, IMapper imapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _imapper = imapper ?? throw new ArgumentNullException(nameof(imapper));
        }

        public async Task<User?> CreateUser(CreateUserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "User data cannot be null.");
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(userDto.FirstName) ||
                string.IsNullOrWhiteSpace(userDto.LastName) ||
                string.IsNullOrWhiteSpace(userDto.Email) ||
                string.IsNullOrWhiteSpace(userDto.Password))
            {
                return null;
            }

            // Check if user already exists
            var existingUser = _unitOfWork.userRepository.GetAll()
                .FirstOrDefault(u => u.Email == userDto.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            // Map DTO to User entity
            var user = _imapper.Map<User>(userDto);
            user.UserName = userDto.Email; // Set UserName to Email

            return await _unitOfWork.userRepository.Create(user, userDto.Password);
        }

        public List<User> GetAllUsers()
        {
            return _unitOfWork.userRepository.GetAll();
        }

        public async Task<User?> GetUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return await _unitOfWork.userRepository.Get(id);
        }

        public async Task<User?> UpdateUser(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Id))
            {
                return null;
            }

            var existingUser = await _unitOfWork.userRepository.Get(user.Id);
            if (existingUser == null)
            {
                return null;
            }

            // Update only allowed fields
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;

            await _unitOfWork.userRepository.Update(existingUser);
            return existingUser;
        }

        public async Task<bool> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            var user = await _unitOfWork.userRepository.Get(id);
            if (user == null)
            {
                return false;
            }

            await _unitOfWork.userRepository.Delete(user);
            return true;
        }
    }
}
