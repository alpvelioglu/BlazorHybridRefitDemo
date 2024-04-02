using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    public class MyApiService : IExternalAPI
    {
        private readonly IExternalAPI _externalAPI;

        public MyApiService(IExternalAPI externalAPI)
        {
            _externalAPI = externalAPI;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _externalAPI.GetProductById(id);
        }
    }
}
