using System;

namespace DC.Web.Ui.ViewModels
{
    public class IlrFileViewModel
    {
        public string Filename { get; set; }

        public Guid CorrelationId { get; set; }

        public DateTime SubmissionDateTime { get; set; }

        public decimal FileSize { get; set; }
    }
}
