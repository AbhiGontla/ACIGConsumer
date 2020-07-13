using Core;
using Core.Api;
using Core.Domain;
using Core.Domain.Customer;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWorks : IUnitOfWorks
    {

        private readonly ACIGDbContext _context;

        public UnitOfWorks(ACIGDbContext context)
        {
            _context = context;
        }
        

        bool disposed = false;

        private IRepository<Customer> customerRepository;
        private IRepository<Registration> registrationRepository;
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                    this.customerRepository = new Repository<Customer>(_context);
                return customerRepository;
            }

        }
        public IRepository<Registration> RegistrationRepository
        {
            get
            {
                if (this.registrationRepository == null)
                    this.registrationRepository = new Repository<Registration>(_context);
                return registrationRepository;
            }

        }
        private IRepository<Approvals> approvalsRepository;
        public IRepository<Approvals> ApprovalsRepository
        {
            get
            {
                if (this.approvalsRepository == null)
                    this.approvalsRepository = new Repository<Approvals>(_context);
                return approvalsRepository;
            }

        }

        private IRepository<Policies> policiesRepository;
        public IRepository<Policies> PoliciesRepository
        {
            get
            {
                if (this.policiesRepository == null)
                    this.policiesRepository = new Repository<Policies>(_context);
                return policiesRepository;
            }

        }
        private IRepository<CoverageBalance> coverageBalanceRepository;
        public IRepository<CoverageBalance> CoverageBalanceRepository
        {
            get
            {
                if (this.coverageBalanceRepository == null)
                    this.coverageBalanceRepository = new Repository<CoverageBalance>(_context);
                return coverageBalanceRepository;
            }

        }

        private IRepository<Providers> providersRepository;
        public IRepository<Providers> ProvidersRepository
        {
            get
            {
                if (this.providersRepository == null)
                    this.providersRepository = new Repository<Providers>(_context);
                return providersRepository;
            }

        }
        private IRepository<PaidClaims> paidClaimsRepository;
        public IRepository<PaidClaims> PaidClaimsRepository
        {
            get
            {
                if (this.paidClaimsRepository == null)
                    this.paidClaimsRepository = new Repository<PaidClaims>(_context);
                return paidClaimsRepository;
            }

        }
        private IRepository<OSClaims> osClaimsRepository;
        public IRepository<OSClaims> OSClaimsRepository
        {
            get
            {
                if (this.osClaimsRepository == null)
                    this.osClaimsRepository = new Repository<OSClaims>(_context);
                return osClaimsRepository;
            }

        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = _context.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }
    }
}
