using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class HotelDetail
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Nullable<bool> WifiInRooms { get; set; }
        public Nullable<bool> WifiInLobby { get; set; }
        public Nullable<bool> SatelliteTV { get; set; }
        public Nullable<bool> Restaurant { get; set; }
        public Nullable<bool> LaundryService { get; set; }
        public Nullable<bool> SafeDepositBox { get; set; }
        public Nullable<bool> WheelchairAccess { get; set; }
        public Nullable<bool> AC { get; set; }
        public Nullable<bool> RoomService { get; set; }
        public Nullable<bool> Lift { get; set; }
        public Nullable<bool> NonSmokingRooms { get; set; }
        public Nullable<bool> Kitchenette { get; set; }
        public Nullable<bool> MiniBarFridge { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
