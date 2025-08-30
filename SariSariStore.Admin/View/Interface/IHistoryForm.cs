using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Admin.View.Interface
{
    public interface IHistoryForm
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int SelectedYear { get; set; }
        int SelectedMonth { get; set; }

        void DisplayOrders(List<Orders> orders);
        void DisplayMonthlyIncome(decimal income);
        void DisplayMonthlyComparison(Dictionary<string, decimal> monthlyData);
        void ShowMessage(string message);


    }
}
