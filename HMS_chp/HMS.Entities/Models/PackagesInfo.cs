using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackagesInfo
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int StatusId { get; set; }
        public int Duration { get; set; }
        public int ClientId { get; set; }
        public Nullable<decimal> PricePerPerson { get; set; }
        public int PriceTypeId { get; set; }
        public int DistanceUnitId { get; set; }
        public int PackageTypeId { get; set; }
        public string HotelNameMakka { get; set; }
        public decimal HotelDistanceMakka { get; set; }
        public string HotelNameMadinah { get; set; }
        public decimal HotelDistanceMadinah { get; set; }
        public int PeoplePerRooms { get; set; }
        public bool IsFlightDepRetDateExist { get; set; }
        public string FlightsDepart { get; set; }
        public string FlightsReturn { get; set; }
        public string Remarks { get; set; }
        public int ShiftingId { get; set; }
        public string SetBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public int HotelClassId { get; set; }
        public int PackagesubscribeId { get; set; }
        public int PackageDisplayTypeId { get; set; }
        public string PackageDisplayInput { get; set; }
        public System.DateTime PackageCreationdate { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
        public virtual DistanceUnit DistanceUnit { get; set; }
        public virtual Duration Duration1 { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual PackageDisplayType PackageDisplayType { get; set; }
        public virtual PackageSubscribe PackageSubscribe { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual PeoplePerRoom PeoplePerRoom { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual Shifting Shifting { get; set; }
        public virtual Statuss Statuss { get; set; }
    }
}
