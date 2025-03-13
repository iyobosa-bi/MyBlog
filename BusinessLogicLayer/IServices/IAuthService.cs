//using DomainLayer.Model;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BusinessLogicLayer.IServices
//{
//    public interface IAuthService
//    {
//        /// <summary>
//        /// Authenticate a user by username/email and password
//        /// </summary>
//        /// <param name="username">Username or email</param>
//        /// <param name="password">User password</param>
//        /// <param name="message">Output message about the login result</param>
//        /// <returns>User object if authentication successful, otherwise null</returns>
//        Task<User?> Login(string email, string password);

//        /// <summary>
//        /// Check if the provided password is valid for the specified user
//        /// </summary>
//        /// <param name="user">The user to check</param>
//        /// <param name="password">The password to verify</param>
//        /// <returns>True if password is valid, otherwise false</returns>
//        Task<bool> CheckPassword(User user, string password);

//        /// <summary>
//        /// Generate a password reset token for a user
//        /// </summary>
//        /// <param name="user">The user requiring password reset</param>
//        /// <returns>Password reset token</returns>
//        Task<string> GeneratePasswordResetToken(User user);

//        /// <summary>
//        /// Reset a user's password using a reset token
//        /// </summary>
//        /// <param name="user">The user</param>
//        /// <param name="token">Password reset token</param>
//        /// <param name="newPassword">New password</param>
//        /// <param name="message">Output message about the operation result</param>
//        /// <returns>True if password was reset successfully, otherwise false</returns>
//        Task<bool> ResetPassword(User user, string token, string newPassword, out string message);

//        /// <summary>
//        /// Sign out the current user
//        /// </summary>
//        Task SignOut();

//        /// <summary>
//        /// Confirm a user's email address using a token
//        /// </summary>
//        /// <param name="user">The user</param>
//        /// <param name="token">Email confirmation token</param>
//        /// <returns>True if email was confirmed successfully, otherwise false</returns>
//        Task<bool> ConfirmEmail(User user, string token);

//        /// <summary>
//        /// Generate an email confirmation token for a user
//        /// </summary>
//        /// <param name="user">The user requiring email confirmation</param>
//        /// <returns>Email confirmation token</returns>
//        Task<string> GenerateEmailConfirmationToken(User user);

//        /// <summary>
//        /// Check if a user's email is confirmed
//        /// </summary>
//        /// <param name="user">The user to check</param>
//        /// <returns>True if email is confirmed, otherwise false</returns>
//        Task<bool> IsEmailConfirmed(User user);

//        /// <summary>
//        /// Change a user's password
//        /// </summary>
//        /// <param name="user">The user</param>
//        /// <param name="currentPassword">Current password</param>
//        /// <param name="newPassword">New password</param>
//        /// <param name="message">Output message about the operation result</param>
//        /// <returns>True if password was changed successfully, otherwise false</returns>
//        Task<bool> ChangePassword(User user, string currentPassword, string newPassword, out string message);
//    }
//}