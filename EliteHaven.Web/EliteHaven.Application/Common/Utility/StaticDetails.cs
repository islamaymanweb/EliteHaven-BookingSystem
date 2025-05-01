namespace EliteHaven.Application.Common.Utility;


public static class StaticDetails
{
    #region HelperFields
    
    public const string RoleAdmin = "Admin";
   
    public const string RoleCustomer = "Customer";
    
    public const string StatusPending = "Pending";
    
    public const string StatusApproved = "Approved";
   
    public const string StatusCheckIn = "CheckIn";
   
    public const string StatusCompleted = "Completed";
   
    public const string StatusCancelled = "Cancelled";
   
    public const string StatusRefunded = "Refunded";
    #endregion

   
    public static int VillaRoomsAvailableCount(int villaId, List<VillaNumber> villaNumberList, DateTime checkInDate, int nights, List<Booking> bookings)
    {
        int roomsInVilla = villaNumberList.Where(v => v.VillaId == villaId).Count();
        int finalAvailableRoomsForAllNights = int.MaxValue;
        List<int> bookingInDate = new();

        for (int i = 0; i < nights; i++)
        {
            var villasBooked = bookings.Where(v => v.VillaId == villaId && v.CheckInDate <= checkInDate.AddDays(i) && v.CheckOutDate > checkInDate.AddDays(i));

            foreach (var booking in villasBooked)
            {
                if (!bookingInDate.Contains(booking.Id))
                {
                    bookingInDate.Add(booking.Id);
                }
            }

            var totalAvailableRooms = roomsInVilla - bookingInDate.Count();

            if (totalAvailableRooms == 0) return 0;
            else
            {
                if (finalAvailableRoomsForAllNights > totalAvailableRooms)
                {
                    finalAvailableRoomsForAllNights = totalAvailableRooms;
                }
            }
        }

        return finalAvailableRoomsForAllNights;
    }

    public static RadialBarChartDTO GetRadialChartDataModel(int totalCount, double currentMonthCount, double prevMonthCount)
    {
        RadialBarChartDTO radialBarChartDTO = new();
        int increaseDecreaseRatio = 100;

        if (prevMonthCount != 0)
        {
            increaseDecreaseRatio = Convert.ToInt32((currentMonthCount - prevMonthCount) / prevMonthCount * 100);
        }

        radialBarChartDTO.TotalCount = totalCount;
        radialBarChartDTO.CountInCurrentMonth = Convert.ToInt32(currentMonthCount);
        radialBarChartDTO.HasRatioIncreased = currentMonthCount > prevMonthCount;
        radialBarChartDTO.Series = new int[] { increaseDecreaseRatio };

        return radialBarChartDTO;
    }
}
