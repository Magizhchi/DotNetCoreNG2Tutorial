using System;
using System.Collections.Generic;

namespace CoreNG2Tutorial.Models
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public int? Argument1 { get; set; }
        public int? Argument2 { get; set; }
        public int? Result { get; set; }
        public int OperationId { get; set; }

        public virtual Operations Operation { get; set; }
    }
}
