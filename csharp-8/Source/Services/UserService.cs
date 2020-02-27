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
            List<int> acceletarionIds = CodenationContext.Accelerations.Where(a => a.Name == name).Select(a => a.Id).ToList();

            IList<User> users = new List<User>();

            Parallel.ForEach(acceletarionIds, action =>
            {
                users.Add(FindById(acceletarionIds.FirstOrDefault()));
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
            return CodenationContext.Users.FirstOrDefault(u => u.Id == id);
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
