using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.BLL.Services;
using System;
using System.Web.Helpers;
using System.Web.Security;

namespace ProjectManagement.AspNetMvc.PL.Providers
{
    public class UserMembershipProvider : MembershipProvider
    {
        //private readonly IUserService _userService;

        //private readonly IUserService _userService;
        //private readonly IRoleService _roleService;// = (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));

        // Exist for config initialization
        public UserMembershipProvider() { }

        //public UserMembershipProvider(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public MembershipUser CreateUser(BllUser user)
        {
            var _userService = (UserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserService));

            if (_userService.IsUserLoginExist(user.Login))
                return null;

            _userService.Create(user);

            var membershipUser = GetUser(user.Login, false);
            return membershipUser;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            //logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
            //userService =
            //   (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));

            //BllUser bllUser = userService.GetByName(username);
            //if (bllUser == null)
            //{
            //    logger.Log(LogLevel.Debug, "Try change password not exist user username = {0}", username);
            //    return false;
            //}

            //if (!Crypto.VerifyHashedPassword(bllUser.PasswordHash, oldPassword))
            //{
            //    logger.Log(LogLevel.Debug, "Try change password with incorrect password user username = {0}", username);
            //    return false;
            //}
            //bllUser.PasswordHash = Crypto.HashPassword(newPassword);
            //userService.Update(bllUser);
            //logger.Log(LogLevel.Trace, "Password cnahged. Username = {0}", username);
            return true;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var _userService = (UserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserService));

            var user = _userService.GetByLogin(username);
            if (user == null)
                return null;

            return new MembershipUser(
                providerName: "UserMembershipProvider",
                name: username,
                providerUserKey: user.Id,
                email: null,
                passwordQuestion: null,
                comment: null,
                isApproved: false,
                isLockedOut: false,
                creationDate: DateTime.MinValue,
                lastLoginDate: DateTime.MinValue,
                lastActivityDate: DateTime.MinValue,
                lastPasswordChangedDate: DateTime.MinValue,
                lastLockoutDate: DateTime.MinValue);
        }

        public override bool ValidateUser(string username, string password)
        {
            IUserService _userService = (UserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserService));
            var user = _userService.GetByLogin(username);
            if (user == null)
                return false;

            if (Crypto.VerifyHashedPassword(user.PasswordHash, password))
                return true;

            return false;
        }

        #region Not Implemented

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey,
            out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }


        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }


        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch,
            int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex,
            int pageSize,
            out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new System.NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}
