using System;

namespace ArcommAdminTool.AbsenceAnnouncements.Entities
{
    public class Absence
    {
        public AbsentUser User { get; set; }

        public Operation Operation { get; set; }

        public bool IsFuture => Operation.Starts_at.Date > DateTime.Now.ToUniversalTime();
    }
}