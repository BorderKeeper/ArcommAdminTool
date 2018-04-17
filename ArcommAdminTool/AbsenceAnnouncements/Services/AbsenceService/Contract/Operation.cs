using System;

namespace ArcommAdminTool.AbsenceAnnouncements.Services.AbsenceService.Contract
{
    public class Operation
    {
        public OperationStart Starts_at { get; set; }
    }

    public class OperationStart
    {
        public DateTime Date { get; set; }

        public string Timezone { get; set; }
    }
}