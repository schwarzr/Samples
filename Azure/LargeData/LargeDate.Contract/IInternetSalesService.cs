using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LargeData.Model;
using LargeData.Model.Custom;

namespace LargeDate.Contract
{
    public interface IInternetSalesService : ITrackable
    {
        Task<IEnumerable<InternetSaleInfo>> GetInternetSaleInfosAsync(DateTime? from, DateTime? until);

        Task<Stream> GetInternetSaleInfoStreamAsync(DateTime? from, DateTime? until);

        Task<IEnumerable<InternetSale>> GetInternetSalesAsync(DateTime? from, DateTime? until);
    }
}