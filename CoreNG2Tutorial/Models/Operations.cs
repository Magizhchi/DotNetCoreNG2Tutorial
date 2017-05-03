using System;
using System.Collections.Generic;

namespace CoreNG2Tutorial.Models
{
    public partial class Operations
    {
        public Operations()
        {
            History = new HashSet<History>();
        }

        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public string OperationDesc { get; set; }

        public virtual ICollection<History> History { get; set; }
        public virtual Operations Operation { get; set; }
        public virtual Operations InverseOperation { get; set; }
    }
}
