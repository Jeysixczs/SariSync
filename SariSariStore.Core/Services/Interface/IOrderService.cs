using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Services.Interface
{
    public interface IOrderService
    {
        Task<List<Orders>> GetAllOrdersAsync();
        Task<List<Orders>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetMonthlyIncomeAsync(int year, int month);
        Task<Dictionary<string, decimal>> GetMonthlyComparisonAsync(int year);
    }
}
