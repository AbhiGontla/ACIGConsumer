using Core;
using Core.Api;
using Core.Domain;
using Core.Domain.Customer;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWorks
    {
        void Save();

        Task SaveAsync();

        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Registration> RegistrationRepository { get; }
        IRepository<Approvals> ApprovalsRepository { get; }
        IRepository<Policies> PoliciesRepository { get; }
        IRepository<CoverageBalance> CoverageBalanceRepository { get; }
        IRepository<Providers> ProvidersRepository { get; }
        IRepository<PaidClaims> PaidClaimsRepository { get; }
        IRepository<OSClaims> OSClaimsRepository { get; }
        IRepository<MRClaimType> ClaimTypeRepository { get; }
        IRepository<BankMaster> BankRepository { get; }
    }
}
