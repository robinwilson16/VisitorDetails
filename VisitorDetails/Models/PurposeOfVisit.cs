using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorDetails.Models
{
    [Table("VIS_PurposeOfVisit")]
    public class PurposeOfVisit
    {
        public int PurposeOfVisitID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }
    }
}
