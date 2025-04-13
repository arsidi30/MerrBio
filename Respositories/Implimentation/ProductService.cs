using FarmIt.Models.Domain;
using FarmIt.Models.DTO;
using FarmIt.Repositories.Abstract;

namespace FarmIt.Repositories.Implementation
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext ctx;
        public ProductService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Product model)
        {
            try
            {
                
                ctx.Product.Add(model);
                ctx.SaveChanges();
                foreach (int categoryId in model.Categorys)
                {
                    var productCategory = new ProductCategory
                    {
                        ProductId = model.Id,
                        CategoryId = categoryId
                    };
                    ctx.ProductCategory.Add(productCategory);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                var productCategorys= ctx.ProductCategory.Where(a => a.ProductId == data.Id);
                foreach(var productCategory in productCategorys)
                {
                    ctx.ProductCategory.Remove(productCategory);
                }
                ctx.Product.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product GetById(int id)
        {
            return ctx.Product.Find(id);
        }

        public ProductListVm List(string term="",bool paging=false, int currentPage=0)
        {
            var data = new ProductListVm();
           
            var list = ctx.Product.ToList();
           
           
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a => a.Title.ToLower().StartsWith(term)).ToList();
            }

            if (paging)
            {
                // here we will apply paging
                int pageSize = 5;
                int count = list.Count;
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1)*pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }

            foreach (var product in list)
            {
                var categorys = (from category in ctx.Category
                              join mg in ctx.ProductCategory
                              on category.Id equals mg.CategoryId
                              where mg.ProductId == product.Id
                              select category.CategoryName
                              ).ToList();
                var categoryNames = string.Join(',', categorys);
                product.CategoryNames = categoryNames;
            }
            data.ProductList = list.AsQueryable();
            return data;
        }

        public bool Update(Product model)
        {
            try
            {
                
                var categoryToDeleted = ctx.ProductCategory.Where(a => a.ProductId == model.Id && !model.Categorys.Contains(a.CategoryId)).ToList();
                foreach(var mCategory in categoryToDeleted)
                {
                    ctx.ProductCategory.Remove(mCategory);
                }
                foreach (int catId in model.Categorys)
                {
                    var productCategory = ctx.ProductCategory.FirstOrDefault(a => a.ProductId == model.Id && a.CategoryId == catId);
                    if (productCategory == null)
                    {
                        productCategory = new ProductCategory { CategoryId = catId, ProductId = model.Id };
                        ctx.ProductCategory.Add(productCategory);
                    }
                }

                ctx.Product.Update(model);
                // we have to add these category ids in productCategory table
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetCategoryByProductId(int productId)
        {
            var categoryIds = ctx.ProductCategory.Where(a => a.ProductId == productId).Select(a => a.CategoryId).ToList();
            return categoryIds;
        }
       
    }
}
