using System;
using System.Collections.Generic;
using ArcommAdminTool.Common.Extensions;

namespace ArcommAdminTool.AbsenceAnnouncements.Services.AbsenceService.Contract
{
    public class Absences
    {
        public IEnumerable<Absence> Data { get; set; }
    }

    public class Absence
    {
        public AbsentUser User { get; set; }

        public Operation Operation { get; set; }

        public DateTime StartingSunday => DateTime.UtcNow.StartOfWeek(DayOfWeek.Sunday);

        public bool IsFuture => Operation.Starts_at.Date > DateTime.UtcNow.ToUniversalTime();
       
        public bool ThisWeek => Operation.Starts_at.Date <= StartingSunday.AddDays(7) && Operation.Starts_at.Date >= StartingSunday;
    }
}