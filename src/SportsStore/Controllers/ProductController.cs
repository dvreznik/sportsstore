using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Linq;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;


        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List(string category,int page = 1)
            => View(new ProductListViewModel
            {
                Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                    _repository.Products.Count() : 
                    _repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}