using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;
using System.Data.Entity;

namespace HMS.Service
{
    public class HMSInitialize : CreateDatabaseIfNotExists<HMSContext>
    {
        protected override void Seed(HMSContext context)
        {

            var UserAccount = new List<UserAccount>
            {
                new UserAccount {  Id = "mohebbo",Password="123",UserRole = 1, SetDate = DateTime.Now,SetBy="Admin" },
                new UserAccount {  Id = "Admin",Password="123",UserRole = 1, SetDate = DateTime.Now,SetBy="Admin"  },
                new UserAccount {  Id = "sumon",Password="123",UserRole = 1, SetDate = DateTime.Now,SetBy="Admin"  }
            };
            UserAccount.ForEach(s => context.UserAccounts.Add(s));
            context.SaveChanges();

            var Subscribe = new List<Subscribe>
            {
                new Subscribe {  Email = "mohebbo@yahoo.com",SetDate= DateTime.Now},
                new Subscribe {  Email = "mohebbo@outlook.com",SetDate= DateTime.Now},
                new Subscribe {  Email = "mohebbo@gmail.com",SetDate= DateTime.Now},
                new Subscribe {  Email = "mohebbo@banyan-technologies.com",SetDate= DateTime.Now}
            };
            Subscribe.ForEach(s => context.Subscribes.Add(s));
            context.SaveChanges();



            var binaryObjectType = new List<binaryObjectType>
            {
                new binaryObjectType{Name = "Application"},
                new binaryObjectType{Name = "Advertice"},
                new binaryObjectType{Name = "Hotel"},
                new binaryObjectType{Name = "PackageSource"},
                new binaryObjectType{Name = "DefaultAdvertice"},
                new binaryObjectType{Name = "Event"}
                
            };
            binaryObjectType.ForEach(s => context.binaryObjectTypes.Add(s));
            context.SaveChanges();

            byte[] binObject = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/add.png");
            byte[] LogoZamZam = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/logoZamZam.png");
            byte[] logoAlHidaaya = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/logoAlHidaaya.jpg");


            byte[] position1 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/add.png");
            byte[] position2 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/add1.png");
            byte[] position3 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/add2.png");
            byte[] position4 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/add3.png");

            byte[] EventDoc1 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/CvMohebbo.pdf");
            byte[] EventDoc2 = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/CvMohebbo.pdf");
            byte[] EventLogo = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/calender.jpg");
            byte[] NotFound = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/notFound.jpg");

            byte[] Add1NewsEvent = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/Add1NewsEvent.jpg");
            byte[] Add2NewsEvent = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/Add2NewsEvent.jpg");
            byte[] Add3NewsEvent = System.IO.File.ReadAllBytes("D:/HajjManagementProject/HMS/HMS/HMS/Content/images/Add3NewsEvent.jpg");



            var binaryObject = new List<binaryObject>
            {
                
                new binaryObject{Name = "AdverticePOS1",Extension = ".png",Object = binObject,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "AdverticePOS2",Extension = ".png",Object = binObject,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "Hotel",Extension = ".png",Object = binObject,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "LogoZamZam",Extension = ".png",Object = LogoZamZam,ObjectTypeId = 4,Path = ""},
                new binaryObject{Name = "logoAlHidaaya",Extension = ".jpg",Object = logoAlHidaaya,ObjectTypeId = 4,Path = ""},

                new binaryObject{Name = "Addposition1",Extension = ".png",Object = position1,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "Addposition2",Extension = ".png",Object = position2,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "Addposition3",Extension = ".png",Object = position3,ObjectTypeId = 2,Path = ""},
                new binaryObject{Name = "Addposition4",Extension = ".png",Object = position4,ObjectTypeId = 2,Path = ""},

                new binaryObject{Name = "EventDoc1",Extension = ".pdf",Object = EventDoc1,ObjectTypeId = 6,Path = ""},
                new binaryObject{Name = "EventDoc2",Extension = ".pdf",Object = EventDoc2,ObjectTypeId = 6,Path = ""},
                new binaryObject{Name = "EventLogo",Extension = ".png",Object = EventLogo,ObjectTypeId = 6,Path = ""},
                new binaryObject{Name = "NotFound",Extension = ".jpg",Object = NotFound,ObjectTypeId = 1,Path = "~/binaryObj/13NotFound.jpg"},
                new binaryObject{Name = "NotFoundpdf",Extension = ".pdf",Object = NotFound,ObjectTypeId = 1,Path = "~/binaryObj/14NotFound.pdf"},

                new binaryObject{Name = "Add1NewsEvent",Extension = ".jpg",Object = Add1NewsEvent,ObjectTypeId = 2,Path = "~/binaryObj/15Add1NewsEvent.jpg"},
                new binaryObject{Name = "Add2NewsEvent",Extension = ".jpg",Object = Add2NewsEvent,ObjectTypeId = 2,Path = "~/binaryObj/16Add2NewsEvent.jpg"},
                new binaryObject{Name = "Add3NewsEvent",Extension = ".jpg",Object = Add3NewsEvent,ObjectTypeId = 2,Path = "~/binaryObj/17Add3NewsEvent.jpg"}
                
            };
            binaryObject.ForEach(s => context.binaryObjects.Add(s));
            context.SaveChanges();






            string AppAddPath = HttpContext.Current.Server.MapPath("AppAdds");
            string AddDefaultpath = HttpContext.Current.Server.MapPath("AppDefaultAdds");


            var AdvertisePosition = new List<AdvertisePosition>
            {
                new AdvertisePosition{Name = "Top Search",Description = "This is top right",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "Home Page",Height = 350,Width = 330,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},
                new AdvertisePosition{Name = "Feature Packege1",Description = "This is Feature Packege",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "Home Page",Height = 800,Width = 300,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},
                new AdvertisePosition{Name = "Feature Packege2",Description = "This is Feature Packege2",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "Home Page",Height = 370,Width = 309,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},
                new AdvertisePosition{Name = "Feature Packege3",Description = "This is Feature Packege2",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "Home Page",Height = 370,Width = 309,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},

                new AdvertisePosition{Name = "Add1NewsEvent",Description = "This is Feature Packege2",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "news event",Height = 370,Width = 309,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},
                new AdvertisePosition{Name = "Add2NewsEvent",Description = "This is Feature Packege2",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "news event",Height = 370,Width = 309,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now},
                new AdvertisePosition{Name = "Add3NewsEvent",Description = "This is Feature Packege2",IMGLocation = AppAddPath,DefaultLocation = AddDefaultpath,PageName = "news event",Height = 370,Width = 309,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now}
                //new AdvertisePosition{Name = "Feature Packege4",Description = "This is Feature Packege3",Height = 170,Width = 80,Amount = 1000,SetBy = "Admin",SetDate = DateTime.Now}
            };
            AdvertisePosition.ForEach(s => context.AdvertisePositions.Add(s));
            context.SaveChanges();



            var AdvertiseType = new List<AdvertiseType>
            {
                new AdvertiseType{Name = "Image"},
                new AdvertiseType{Name = "Script"}
                
            };
            AdvertiseType.ForEach(s => context.AdvertiseTypes.Add(s));
            context.SaveChanges();






            var Advertise = new List<Advertise>
            {
                new Advertise{Name = "TopSearch",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 6,PositionId = 1,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "TopSearch",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 6,PositionId = 1,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "FeaturePackege",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 7,PositionId = 2,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "FeaturePackege",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 7,PositionId = 2,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "FeaturePackege2",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 8,PositionId = 3,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "FeaturePackege2",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 8,PositionId = 3,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "FeaturePackege3",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 9,PositionId = 4,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "FeaturePackege3",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 9,PositionId = 4,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "Add1NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 15,PositionId = 5,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Add1NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 15,PositionId = 5,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                
                new Advertise{Name = "Add2NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 16,PositionId = 6,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Add2NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 16,PositionId = 6,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                
                new Advertise{Name = "Add3NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 17,PositionId = 7,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Add3NewsEvent",Type = 1,Script = "NULL",Extension = ".jpg",BinaryObjectId = 17,PositionId = 7,FromDate = Convert.ToDateTime("01-Aug-2014"),ToDate = Convert.ToDateTime("01-Aug-2015"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now}
            };
            Advertise.ForEach(s => context.Advertises.Add(s));
            context.SaveChanges();


            var Duration = new List<Duration>
            {
                new Duration {TotalDuration  = "Any",Description = "Any",SetBy = "Admin",SetDate = DateTime.Now},
                new Duration {TotalDuration = "10 days",Description = "10",SetBy = "Admin",SetDate = DateTime.Now},
                new Duration {TotalDuration = "11 to 15 days",Description = "15",SetBy = "Admin",SetDate = DateTime.Now},
                new Duration {TotalDuration = "16 to 21 days",Description = "21",SetBy = "Admin",SetDate = DateTime.Now},
                new Duration {TotalDuration = "22 to 30 days",Description = "30",SetBy = "Admin",SetDate = DateTime.Now},
                new Duration {TotalDuration = "31+ days",Description = "31",SetBy = "Admin",SetDate = DateTime.Now}
            };
            Duration.ForEach(s => context.Durations.Add(s));
            context.SaveChanges();

            var PeoplePerRoom = new List<PeoplePerRoom>
            {
                new PeoplePerRoom {RoomCapacity  = "Any",Description = "Any",SetBy = "Admin",SetDate = DateTime.Now},
                new PeoplePerRoom {RoomCapacity = "2",Description = "10 days",SetBy = "Admin",SetDate = DateTime.Now},
                new PeoplePerRoom {RoomCapacity = "3",Description = "11 to 15 days",SetBy = "Admin",SetDate = DateTime.Now},
                new PeoplePerRoom {RoomCapacity = "4",Description = "16 to 21 days",SetBy = "Admin",SetDate = DateTime.Now}
            };
            PeoplePerRoom.ForEach(s => context.PeoplePerRooms.Add(s));
            context.SaveChanges();


            var Hotel = new List<Hotel>
            {
                new Hotel {Star  = "Any",Description = "Any",DistanceFromHaram = 5,SetDate = DateTime.Now},
                new Hotel {Star = "1 star",Description = "1 star",DistanceFromHaram = 5,SetDate = DateTime.Now},
                new Hotel {Star = "2 star",Description = "2 star",DistanceFromHaram = 5,SetDate = DateTime.Now},
                new Hotel {Star = "3 star",Description = "3 star",DistanceFromHaram = 5,SetDate = DateTime.Now},
                new Hotel {Star = "4 star",Description = "4 star",DistanceFromHaram = 5,SetDate = DateTime.Now},
                new Hotel {Star = "5 star",Description = "5 star",DistanceFromHaram = 5,SetDate = DateTime.Now}
            };
            Hotel.ForEach(s => context.Hotels.Add(s));
            context.SaveChanges();


            var HotelDetail = new List<HotelDetail>
            {
                new HotelDetail{HotelId = 1,AC = true,Kitchenette = true,LaundryService = true,Lift = true,MiniBarFridge = true,NonSmokingRooms = true,Restaurant = true,RoomService = true,SafeDepositBox = true,SatelliteTV = true,WheelchairAccess = true,WifiInLobby = false,WifiInRooms = true},
                new HotelDetail{HotelId = 2,AC = true,Kitchenette = true,LaundryService = true,Lift = true,MiniBarFridge = true,NonSmokingRooms = true,Restaurant = true,RoomService = true,SafeDepositBox = true,SatelliteTV = true,WheelchairAccess = true,WifiInLobby = false,WifiInRooms = true},
                new HotelDetail{HotelId = 3,AC = true,Kitchenette = true,LaundryService = true,Lift = true,MiniBarFridge = true,NonSmokingRooms = true,Restaurant = true,RoomService = true,SafeDepositBox = true,SatelliteTV = true,WheelchairAccess = true,WifiInLobby = false,WifiInRooms = true},
                new HotelDetail{HotelId = 4,AC = true,Kitchenette = true,LaundryService = true,Lift = true,MiniBarFridge = true,NonSmokingRooms = true,Restaurant = true,RoomService = true,SafeDepositBox = true,SatelliteTV = true,WheelchairAccess = true,WifiInLobby = false,WifiInRooms = true},
                new HotelDetail{HotelId = 5,AC = true,Kitchenette = true,LaundryService = true,Lift = true,MiniBarFridge = true,NonSmokingRooms = true,Restaurant = true,RoomService = true,SafeDepositBox = true,SatelliteTV = true,WheelchairAccess = true,WifiInLobby = false,WifiInRooms = true}
                

            };
            HotelDetail.ForEach(s => context.HotelDetails.Add(s));
            context.SaveChanges();






            var RecentSearch = new List<RecentSearch>
            {
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now},
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now},
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now},
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now},
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now},
                new RecentSearch {SessionKey = "123456",From  = "London Heathrow",Duration = 1,HotelClass = 1,PepolePerRoom = 1,SetDate = DateTime.Now}
            };
            RecentSearch.ForEach(s => context.RecentSearchs.Add(s));
            context.SaveChanges();



            var PackageSource = new List<PackageSource>
            {
                new PackageSource {Name = "Alhidaayah", SetBy = "Admin", SetDate = DateTime.Now,LogoId = 5},
                new PackageSource {Name = "Zam Zam", SetBy = "Admin", SetDate = DateTime.Now,LogoId = 4}
            };
            PackageSource.ForEach(s => context.PackageSources.Add(s));
            context.SaveChanges();

            /*
            var Event = new List<Event>
            {
                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },

                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },

                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },

                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },

                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },
                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                },
                new Event 
                {
                    Title = "Hajj camp",Language = "Bangla", Type = 2,Date = DateTime.Today.AddDays(-5),EndDate = null,
                    Venue = "London",Address = "South Woodford Mosque 14 Mulberry Way",PostCode = "1234",OrgWebsite = "careers.brac.net",OrgPhone = "+8801717525251",OrgEmail = "mohebbo@yahoo.com",
                    OrgContactAddress = "London",DocumentId1 = 10,Logo = 12,
                    YourName = "Md. Samnoon Mohebbo",YourEmail = "mohebbo@gmail.com",YourOrganisation = "BRAC",YourPhone = "01766554324"
                }

                
            };
            Event.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
            */
            /*
            var Advertise = new List<Advertise>
            {
               

                new Advertise{Name = "Top Search",Pictute = position1,PositionId = 1,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Top Search",Pictute = position1,PositionId = 1,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "Feature Packege",Pictute = position2,PositionId = 2,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Feature Packege",Pictute = position2,PositionId = 2,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "Feature Packege2",Pictute = position3,PositionId = 3,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Feature Packege2",Pictute = position3,PositionId = 3,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},

                new Advertise{Name = "Feature Packege3",Pictute = position4,PositionId = 4,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = true,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                new Advertise{Name = "Feature Packege3",Pictute = position4,PositionId = 4,FromDate = Convert.ToDateTime("01-12-2013"),ToDate = Convert.ToDateTime("01-01-2014"),IsActive = true,Amount = 10000,IsDefault = false,Address = "This is test Address",ContactNumber = "01717525251",SetBy = "Admin",SetDate = DateTime.Now},
                
            };
            Advertise.ForEach(s => context.Advertises.Add(s));
            context.SaveChanges();
            */

            /*

            var Hotel = new List<Hotel>
            {
                new Hotel { Name = "Shaza Al Madina",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now},
                new Hotel { Name = "Hotels in Jarwal",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now},
                new Hotel { Name = "Hilton",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now},
                new Hotel { Name = "Tulip Inn Riyadh",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now},
                new Hotel { Name = "Mobarak Plaza Hotel",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now},
                new Hotel { Name = "Palestine Hotel",Distance = 10,DistanceFrom = "Modina",Star = 5,Address = "Modina",ContactNumber = "+661234567",SetBy = "Admin",SetDate= DateTime.Now}
                
            };
            Subscribe.ForEach(s => context.Subscribes.Add(s));
            context.SaveChanges();
            */
        }
    }
}