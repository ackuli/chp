using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{

    public class UserAccount
    {
        [Key]
        [Required(ErrorMessage = "UserId is required")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Urer role required")]
        public int UserRole { get; set; }
        public string UserDescription { get; set; }
        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }
        [Display(Name = "Set By")]
        public string SetBy { get; set; }
    }

    public class Subscribe
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }
    }

    public class AdvertisePosition
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Position Name")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "IMG Location")]
        public string IMGLocation { get; set; }

        [Display(Name = "Default Location")]
        public string DefaultLocation { get; set; }

        [Required(ErrorMessage = "Page Name is required")]
        [Display(Name = "Page Name")]
        public string PageName { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Display(Name = "Agency Name")]
        public int Height { get; set; }


        [Required(ErrorMessage = "Width is required")]
        [Display(Name = "Width")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Set By is required")]
        [Display(Name = "Set By")]
        public string SetBy { get; set; }

        [Required(ErrorMessage = "Set Date is required")]
        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }



    }

    public class AdvertiseType
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Agency Name")]
        public string Name { get; set; }

    }

    public class Advertise
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Agency Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Type")]
        public int Type { get; set; }

        [Display(Name = "Pictute")]
        public int? BinaryObjectId { get; set; }


        [Display(Name = "Extension")]
        public string Extension { get; set; }



        [Display(Name = "Script")]
        public string Script { get; set; }

        [Required(ErrorMessage = "Position Id required")]
        [Display(Name = "Position Id")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "From Date is required")]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To Date is required")]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Is Default")]
        [DefaultValue(false)]
        public bool IsDefault { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Display(Name = "Contact Number")]
        [MaxLength(16), MinLength(8)]
        public string ContactNumber { get; set; }




        [Required(ErrorMessage = "Set By is required")]
        [Display(Name = "Set By")]
        public string SetBy { get; set; }

        [Required(ErrorMessage = "Set Date is required")]
        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }



        [ForeignKey("PositionId")]
        public virtual AdvertisePosition Fk_AdvertisePosition { get; set; }

        [ForeignKey("Type")]
        public virtual AdvertiseType Fk_AdvertiseType { get; set; }


        [ForeignKey("BinaryObjectId")]
        public virtual binaryObject Fk_BinaryObjectId { get; set; }


        public IEnumerable<KeyValuePair<int, string>> lstAdvertisePosition { get; set; }
        public IEnumerable<KeyValuePair<int, string>> lstAdvertiseType { get; set; }

    }


    public class RecentSearch
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public string SessionKey { get; set; }

        public string From { get; set; }

        public int Duration { get; set; }

        public int PepolePerRoom { get; set; }

        public int HotelClass { get; set; }

        public DateTime SetDate { get; set; }
    }


    public class AppConfiguration
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Site Name is required")]
        [Display(Name = "Site Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Site URL is required")]
        [Display(Name = "Site URL")]
        public string URL { get; set; }


        [Required(ErrorMessage = "Google Analytics Id is required")]
        [Display(Name = "Google Analytics ID")]
        public string GAnalyticsID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Is Active Analytics")]
        public bool IsActive { get; set; }



        [Display(Name = "Keywords")]
        public string Keywords { get; set; }


        [Display(Name = "Default Country")]
        public string DefaultCountry { get; set; }


        [Display(Name = "Default Language")]
        public string DefaultLanguage { get; set; }


        [Display(Name = "Agency Name")]
        [DefaultValue(false)]
        public bool IsEnableSEO { get; set; }


        [Display(Name = "Is IP Checking For Login")]
        [DefaultValue(false)]
        public bool IsIPCheckingForLogin { get; set; }


        [Display(Name = "Is Enable Captcha For Login")]
        [DefaultValue(false)]
        public bool IsEnableCaptchaForLogin { get; set; }

    }

    public class Duration
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Site Name is required")]
        [Display(Name = "Site Name")]
        public string TotalDuration { get; set; }

        [Display(Name = "Site Name")]
        public string Description { get; set; }


        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }
        [Display(Name = "Set By")]
        public string SetBy { get; set; }
    }

    public class PeoplePerRoom
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Room Capacity is required")]
        [Display(Name = "Room Capacity")]
        public string RoomCapacity { get; set; }

        [Display(Name = "Site Name")]
        public string Description { get; set; }


        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }
        [Display(Name = "Set By")]
        public string SetBy { get; set; }
    }

    public class Hotel
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hotel Type is required")]
        [Display(Name = "Hotel Type")]
        public string Star { get; set; }

        [Required(ErrorMessage = "Hotel Type is required")]
        [Display(Name = "Hotel Type")]
        public int DistanceFromHaram { get; set; }

        [Display(Name = "Site Name")]
        public string Description { get; set; }


        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }


    }

    public class HotelDetail
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Hotel Id is required")]
        public int HotelId { get; set; }

        [Display(Name = "Wifi in rooms")]
        public Nullable<bool> WifiInRooms { get; set; }

        [Display(Name = "Wifi in Lobby")]
        public Nullable<bool> WifiInLobby { get; set; }

        [Display(Name = "Satellite TV")]
        public Nullable<bool> SatelliteTV { get; set; }

        [Display(Name = "Restaurant")]
        public Nullable<bool> Restaurant { get; set; }

        [Display(Name = "Laundry Service")]
        public Nullable<bool> LaundryService { get; set; }

        [Display(Name = "Safe Deposit box")]
        public Nullable<bool> SafeDepositBox { get; set; }

        [Display(Name = "Wheelchair access")]
        public Nullable<bool> WheelchairAccess { get; set; }

        [Display(Name = "AC")]
        public Nullable<bool> AC { get; set; }

        [Display(Name = "Room Service")]
        public Nullable<bool> RoomService { get; set; }

        [Display(Name = "Lift")]
        public Nullable<bool> Lift { get; set; }

        [Display(Name = "Non smoking rooms")]
        public Nullable<bool> NonSmokingRooms { get; set; }

        [Display(Name = "Kitchenette")]
        public Nullable<bool> Kitchenette { get; set; }

        [Display(Name = "Mini-bar or Fridge")]
        public Nullable<bool> MiniBarFridge { get; set; }



        [ForeignKey("HotelId")]
        public virtual Hotel Fk_HotelId { get; set; }
    }



    public class PackageSource
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Source name is required")]
        [Display(Name = "Source")]
        public string Name { get; set; }

        public int LogoId { get; set; }

        [Required(ErrorMessage = "Set By is required")]
        [Display(Name = "Set By")]
        public string SetBy { get; set; }

        [Required(ErrorMessage = "Set Date is required")]
        [Display(Name = "Set Date")]
        public DateTime SetDate { get; set; }

        [ForeignKey("LogoId")]
        public virtual binaryObject Fk_LogoId { get; set; }
    }


    public class Package
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Hotel Name")]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [Required(ErrorMessage = "TotalRoom is required")]
        public int PackageSourceId { get; set; }

        [Required(ErrorMessage = "TotalRoom is required")]
        [Column(TypeName = "VARCHAR(MAX)")]

        public string Details { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int? Duration { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Price Type is required")]
        [Display(Name = "Price Type")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string PriceType { get; set; }

        [Required(ErrorMessage = "Start From is required")]
        [Column(TypeName = "VARCHAR")]
        [DefaultValue("")]
        [MaxLength(150)]
        [Display(Name = "Start From")]
        public string StartFrom { get; set; }

        [Required(ErrorMessage = "Set By is required")]
        [Display(Name = "Set By")]
        public string SetBy { get; set; }

        [Required(ErrorMessage = "SetDate is required")]
        [Display(Name = "Set Date")]
        public string SetDate { get; set; }


        [ForeignKey("PackageSourceId")]
        public virtual PackageSource Fk_PackageSourceId { get; set; }

    }

    public class PackageDetail
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public int PackageId { get; set; }


        public int Details { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package Fk_PackageId { get; set; }
    }

    public class binaryObjectType
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class binaryObject
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ObjectTypeId { get; set; }

        public byte[] Object { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }


        [ForeignKey("ObjectTypeId")]
        public virtual binaryObjectType Fk_ObjectTypeId { get; set; }
    }


    public class Event
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }


        [Display(Name = "Language")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string Language { get; set; }

        [Display(Name = "Type")]
        [Required]
        public int Type { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime Date { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }


        [Display(Name = "Time")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string Time { get; set; }



        [Display(Name = "Venue")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string Venue { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Post Code")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        [Required]
        public string PostCode { get; set; }


        [Display(Name = "Website")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string OrgWebsite { get; set; }

        [Display(Name = "Phone")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string OrgPhone { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string OrgEmail { get; set; }

        [Display(Name = "Contact Address")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string OrgContactAddress { get; set; }

        public int? DocumentId1 { get; set; }
        public int? Logo { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        [Required]
        public string YourName { get; set; }

        [Display(Name = "Organisation")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        [Required]
        public string YourOrganisation { get; set; }

        [Display(Name = "Phone")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        [Required]
        public string YourPhone { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string YourEmail { get; set; }

        public bool IsVisible { get; set; }

        [ForeignKey("DocumentId1")]
        public virtual binaryObject Fk_DocumentId1 { get; set; }
        
        [ForeignKey("Logo")]
        public virtual binaryObject Fk_Logo { get; set; }


        public IEnumerable<KeyValuePair<int, string>> Types { get; set; }

        public Event()
        {
            Types = new[]
            {
                new KeyValuePair<int, string>(1, "Seminar"),
                new KeyValuePair<int, string>(2, "Exhibition "),
                new KeyValuePair<int, string>(3, "Vaccination Programme"),
                new KeyValuePair<int, string>(4, "Ta'leem"),
                new KeyValuePair<int, string>(5, "Other")
            };
        }

    }

    public class QuestionType
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Display(Name = "Question Category")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        public string SetDate { get; set; }

    }

    //public class QuestionAnswer
    //{
    //    [Key]
    //    [Required(ErrorMessage = "Id is required")]
    //    public int Id { get; set; }

    //    [Display(Name = "Name")]
    //    [Column(TypeName = "VARCHAR")]
    //    [MaxLength(50)]
    //    [Required]
    //    public string Name { get; set; }


    //    [Display(Name = "Question")]
    //    [Column(TypeName = "VARCHAR(MAX)")]
    //    [MaxLength(500)]
    //    [Required]
    //    [DataType(DataType.MultilineText)]
    //    public string Question { get; set; }

    //    [Display(Name = "Answer")]
    //    [Column(TypeName = "VARCHAR(MAX)")]
    //    [Required]
    //    public string Answer { get; set; }

    //    [Display(Name = "Description")]
    //    [Column(TypeName = "VARCHAR")]
    //    [MaxLength(10)]
    //    public string ScoloarId { get; set; }
    //    [Display(Name = "Type Id")]
    //    public int TypeId { get; set; }

    //    public int Count { get; set; }

    //    public bool IsVisible { get; set; }
    //    [Column(TypeName = "VARCHAR")]
    //    [Required]
    //    [MaxLength(150)]
    //    [Display(Name = "Email Id")]
    //    public string EmailId { get; set; }

    //    public DateTime AnswerDate { get; set; }

    //    public string SetDate { get; set; }

    //    [ForeignKey("ScoloarId")]
    //    public virtual UserAccount Fk_ScoloarId { get; set; }

    //    [ForeignKey("TypeId")]
    //    public virtual QuestionType Fk_TypeId { get; set; }

    //    public IEnumerable<KeyValuePair<int, string>> Types { get; set; }

    //}

    public class News
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

       
        [Display(Name = "Description")]
        [Column(TypeName = "VARCHAR(MAX)")]
        [Required]
        
        public string Description { get; set; }


        [Display(Name = "Source")]
        [Column(TypeName = "VARCHAR")]
        [Required]
        [MaxLength(150)]
        public string Source { get; set; }


        [Display(Name = "Publish Date")]
        [Required]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Image")]
        [Required]
        public int Img { get; set; }

        public bool IsArchive { get; set; }


        [ForeignKey("Img")]
        public virtual binaryObject Fk_Img { get; set; }
                
    }

    public  class Experience
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "City")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [Display(Name = "Year")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string Year { get; set; }
        [Display(Name = "Email")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Display(Name = "Year")]
        [Column(TypeName = "VARCHAR(MAX)")]
        [Required]
        public string Narratives { get; set; }
        public bool? IsShow { get; set; }

        public bool? IsActive { get; set; }
        public System.DateTime Setdate { get; set; }
    }

}