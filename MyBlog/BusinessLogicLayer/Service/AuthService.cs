//using BusinessLogicLayer.IServices;
//using DataAccessLayer.UnitOfWorkFolder;
//using DomainLayer.Model;
//using System;
//using System.Threading.Tasks;

//namespace BusinessLogicLayer.Service
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public AuthService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<User?> Login(string email, string password)
//        {
//            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//            {
//                return null;
//            }

//            var user = await _unitOfWork.userRepository.FindByUsernameOrEmailAsync(username);

//            if (user == null)
//            {
//                message = "User not found.";
//                return null;
//            }

//            if (!await CheckPassword(user, password))
//            {
//                message = "Invalid password.";
//                return null;
//            }

//            message = "Login successful.";
//            return user;
//        }

//        public async Task<bool> CheckPassword(User user, string password)
//        {
//            // Implement password checking logic here (e.g., hashing and comparing)
//            // This is a placeholder implementation
//            return user.PasswordHash == password; // Replace with secure password hashing
//        }

//        public async Task<string> GeneratePasswordResetToken(User user)
//        {
//            // Implement token generation logic here
//            return Guid.NewGuid().ToString(); // Replace with a secure token generation mechanism
//        }

//        public async Task<bool> ResetPassword(User user, string token, string newPassword, out string message)
//        {
//            // Password reset is not allowed in this implementation
//            message = "Password reset is not supported.";
//            return false;
//        }

//        public async Task SignOut()
//        {
//            // Implement sign-out logic here (e.g., clear session or token)
//        }

//        public async Task<bool> ConfirmEmail(User user, string token)
//        {
//            // Implement email confirmation logic here
//            if (string.IsNullOrEmpty(token))
//            {
//                return false;
//            }

//            // Validate token (placeholder logic)
//            if (token == "valid-token") // Replace with actual token validation
//            {
//                user.EmailConfirmed = true;
//                _unitOfWork.userRepository.Update(user);
//                await _unitOfWork.SaveAsync();
//                return true;
//            }

//            return false;
//        }

//        public async Task<string> GenerateEmailConfirmationToken(User user)
//        {
//            // Implement token generation logic here
//            return Guid.NewGuid().ToString(); // Replace with a secure token generation mechanism
//        }

//        public async Task<bool> IsEmailConfirmed(User user)
//        {
//            return user.EmailConfirmed;
//        }

//        public async Task<bool> ChangePassword(User user, string currentPassword, string newPassword, out string message)
//        {
//            // Password change is not allowed in this implementation
//            message = "Password change is not supported.";
//            return false;
//        }
//    }
//}