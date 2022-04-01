using System;
using System.Collections.Generic;

#nullable disable

namespace PTWServer1.EntityFrameworkModel
{
    public partial class Form
    {
        public int? FormId { get; set; }
        public string FormName { get; set; }
        public DateTime? FormDate { get; set; }
    }
}
