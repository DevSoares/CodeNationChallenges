using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext CodenationContext;
        public CompanyService(CodenationContext context)
        {
            CodenationContext = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            List<int> companiesIds = CodenationContext.Candidates.Where(c => c.AccelerationId == accelerationId).Select(a => a.CompanyId).ToList();

            IList<Company> companies = new List<Company>();

            Parallel.ForEach(companiesIds, action =>
            {
                companies.Add(FindById(companiesIds.FirstOrDefault()));
            });

            return companies;
        }

        public Company FindById(int id)
        {
            return CodenationContext.Companies.Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            List<int> companiesIds = CodenationContext.Candidates.Where(c => c.UserId == userId).Select(a => a.CompanyId).ToList();

            IList<Company> companies = new List<Company>();

            Parallel.ForEach(companiesIds, action =>
            {
                companies.Add(FindById(companiesIds.FirstOrDefault()));
            });

            return companies;
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                CodenationContext.Companies.Add(company);
            else
                CodenationContext.Companies.Update(company);

            CodenationContext.SaveChanges();

            return company;
        }
    }
}