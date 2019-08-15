using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Event
    {
        public int EventsId { get; set; }
        public string EventsTitle { get; set; }
        public string EventDescription { get; set; }
        public string Language { get; set; }
        public int EventsTypeId { get; set; }
        public System.DateTime EventsDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string OrgWebsite { get; set; }
        public string OrgPhone { get; set; }
        public string OrgEmail { get; set; }
        public string OrgContactAddress { get; set; }
        public string Documents { get; set; }
        public string Logo { get; set; }
        public string YourName { get; set; }
        public string YourOrganisation { get; set; }
        public string YourPhone { get; set; }
        public string YourEmail { get; set; }
        public string SetBy { get; set; }
        public bool IsVisible { get; set; }
        public bool IsArchive { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public bool IsAcceptedPrivacyCookiePolicy { get; set; }
        public bool IsAcceptedTermsConditions { get; set; }
        public virtual EventsType EventsType { get; set; }
    }
}
