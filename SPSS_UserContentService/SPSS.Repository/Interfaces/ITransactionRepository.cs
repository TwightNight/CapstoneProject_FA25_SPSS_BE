using SPSS.BusinessObject.Models;
using SPSS.Shared.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPSS.Repository.Interfaces;

public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
{
    Task<IEnumerable<Transaction>> GetPendingTransactionsAsync();
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(Guid userId);
    Task<Transaction?> GetTransactionByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetTransactionsByStatusAsync(string status);
}