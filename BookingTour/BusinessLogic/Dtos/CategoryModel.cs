using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int ModifyBy { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
