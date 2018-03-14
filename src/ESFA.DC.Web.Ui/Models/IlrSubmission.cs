using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC.Web.Ui.Models
{
    public class IlrSubmission
    {
        public string Filename;
        public string ContainerReference;
        public Guid CorrelationId;
        public DateTime SubmissionDateTime { get; set; }
        public decimal FileSize { get; set; }
    }
}
