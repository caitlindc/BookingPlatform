using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Application.Common.Exceptions
{
    internal class UnavailableDatesException : Exception
    {
        public UnavailableDatesException(DateTime dateFrom, DateTime dateTo)
            : base($"Dates \"{dateFrom}\" to \"{dateTo}\" is not available.")
        {
        }
    }
}
