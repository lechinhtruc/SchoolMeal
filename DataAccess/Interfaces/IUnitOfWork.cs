﻿namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IReportRepositories Report { get; }
        IAuthRepositories Auth { get; }
        IAccountRepositories Account { get; }
        IUserLog UserLog { get; }
        IManageAccountsRepositories ManageAccounts { get; }
        ISearchRepositores Search { get; } 
    }
}
