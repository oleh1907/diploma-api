using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaEntities.Models
{
    public class Quality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodInfo> FoodInfos { get; set; }
    }
}
