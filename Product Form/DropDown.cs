using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Form
{
    public  class DropDown
    {
        ProductFormEntities db;
        public DropDown()
        {
             db = new ProductFormEntities();    
        }

        public List<Color>  listColors()
        {
            var list = db.Colors.ToList();
            return list;
        }

    }
}
