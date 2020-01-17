using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Form
{
    public  class DropDown
    {
        VanmeEntities db;
        public DropDown()
        {
             db = new VanmeEntities();    
        }

        public List<Color>  listColors()
        {
            var list = db.Colors.ToList();
            return list;
        }

        public List<Material> listMaterial()
        {
            var list = db.Materials.ToList();
            return list;
        }

        public List<Country> countries()
        {
            var list = db.Countries.ToList();
            return list;
        }
        public List<Category> categories()
        {
            var list = db.Categories.ToList();
            return list;
        }

        public List<SubCategory> subCategories()
        {
            var list = db.SubCategories.ToList();
            return list;
        }
        public List<ProductType> productTypes()
        {
            var list = db.ProductTypes.ToList();
            return list;
        }
        public List<Brand> brands()
        {
            var list = db.Brands.ToList();
            return list;
        }
    }
}
