using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext CodenationContext;
        public UserService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            int acceletarionId = CodenationContext.Accelerations.FirstOrDefault(a => a.Name == name).Id;

            List<int> userIds = CodenationContext.Candidates.Where(c => c.AccelerationId == acceletarionId).Select(c2 => c2.UserId).ToList();

            IList<User> users = new List<User>();

            Parallel.ForEach(userIds, action =>
            {
                users.Add(FindById(userIds.FirstOrDefault()));
            });

            return users;
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            List<int> userIds = CodenationContext.Candidates.Where(c => c.CompanyId == companyId).Select(c2 => c2.UserId).ToList();
            IList<User> users = new List<User>();

            Parallel.ForEach(userIds, action =>
            {
                users.Add(FindById(userIds.FirstOrDefault()));
            });

            return users;
        }

        public User FindById(int id)
        {
            return CodenationContext.Users.Find(id);
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                CodenationContext.Users.Add(user);
            else
                CodenationContext.Users.Update(user);

            CodenationContext.SaveChanges();

            return user;
        }
    }
}
