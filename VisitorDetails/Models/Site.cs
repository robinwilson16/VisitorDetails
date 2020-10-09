using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorDetails.Models
{
    public class Site
    {
        [StringLength(20)]
        public string SiteCode { get; set; }

        [StringLength(100)]
        public string SiteName { get; set; }
        
        [StringLength(36)]
        public string SiteEncryptedCode { get; set; }

        public ICollection<Visitor> Visitor { get; set; }
    }
}
