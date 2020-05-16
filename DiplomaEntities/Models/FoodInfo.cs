using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaEntities.Models
{
    public class FoodInfo
    {
        public int Id { get; set; }
        public string OfficialName { get; set; }
        public string NameToDisplay { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int QualityId { get; set; }
        public Quality Quality { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
