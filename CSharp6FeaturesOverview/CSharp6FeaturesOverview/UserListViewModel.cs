using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp6FeaturesOverview
{
    public class UserListViewModel
    {
        public event EventHandler<User> UserAdded;
        private List<User> userList = new List<User>();

        public void AddUser(User user)
        {
            userList.Add(user);
            UserAdded?.Invoke(this, user);
        }

        public void RemoveUser(User user)
        {
            if (user == null)
            {
                var paramName = nameof(user);
                throw new ArgumentNullException(paramName);
            }
        }

        public User SaveUser(User user, bool retry = true)
        {
            try
            {
                return SaveUserInternal(user, retry);
            }
            catch (RetryableException ex) when (ex.Retryable)
            {
                return SaveUser(user, false);
            }
            catch (RetryableException ex)
            {
                throw new ApplicationException();
            }
        }

        public async Task<User> SaveUserAsync(User user, bool retry = true)
        {
            try
            {
                var startNew = Task.Factory.StartNew(() => SaveUserInternal(user, retry));
                return await startNew;
            }
            catch (RetryableException ex) when (ex.Retryable)
            {
                return await SaveUserAsync(user, false);
            }
            catch (Exception ex)
            {
                throw new ApplicationException();
            }
        }

        private User SaveUserInternal(User user, bool retryable = true)
        {
            throw new RetryableException("Failed to save user", retryable);
            return new User();
        }


    }
}