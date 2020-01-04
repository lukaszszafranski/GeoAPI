using StockAPI.Entities;
using StockAPI.Repositories;
using StockAPI.Repositories.Domain;
using StockAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }

        public User Create(User user, string password)
        {
            return _userRepository.Create(user, password);
        }

        public UserResponse Delete(int id)
        {
            var existingUserData = _userRepository.GetById(id);

            if (existingUserData == null)
            {
                return new UserResponse("Symbol not found");
            }

            try
            {
                _userRepository.Delete(id);
                _unitOfWork.CompleteAsync();

                return new UserResponse(existingUserData);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when deleting the category: {ex.Message}");
            }

        }

        public Task<IEnumerable<User>> GetAll()
        {
           return Task.Run(() => _userRepository.GetAll());
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public UserResponse Update(User user, string password = null)
        {
            _userRepository.Update(user, password);

            return new UserResponse("User was updated");
        }
    }
}
