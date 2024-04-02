using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    public interface IExternalAPI
    {
        [Get("/products/{id}")]
        Task<Product> GetProductById(int id);
    }
}
