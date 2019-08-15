using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModels;

namespace HMS.Utility
{
    public class AdverticeProcessing
    {
        /// <summary>
        /// SET images into server location
        /// </summary>
        /// <param name="lstAddvertice"></param>
        public void setAdverticeImage(List<HMS.Entities.Models.Advertis> lstAddvertice)
        {
            string filePathTemplate = System.Web.HttpContext.Current.Server.MapPath("~/binaryObj/")
                + "\\[imagename]" + "[extenssion]";

            lstAddvertice.ForEach(delegate(HMS.Entities.Models.Advertis advertise)
            {
                string filePath = filePathTemplate.Replace("[imagename]", advertise.AdvertiseId.ToString() + advertise.Name).Replace("[extenssion]", advertise.Extension);
                if (!System.IO.File.Exists(filePath))
                {
                    //if (advertise.PositionId == 1 && advertise.Type == 1)
                    //{
                    //    System.IO.File.WriteAllBytes(filePath, advertise.Fk_BinaryObjectId.Object);
                    //}
                    //else if (advertise.PositionId == 2 && advertise.Type == 1)
                    //{
                    //    System.IO.File.WriteAllBytes(filePath, advertise.Fk_BinaryObjectId.Object);
                    //}
                    //else if (advertise.PositionId == 3 && advertise.Type == 1)
                    //{
                    //    System.IO.File.WriteAllBytes(filePath, advertise.Fk_BinaryObjectId.Object);
                    //}
                    //else if (advertise.PositionId == 4 && advertise.Type == 1)
                    //{
                    //    System.IO.File.WriteAllBytes(filePath, advertise.Fk_BinaryObjectId.Object);
                    //}
                }

            });

        }

        /// <summary>
        /// Create MVC string for advertice
        /// </summary>
        /// <param name="lstAddvertice"></param>
        /// <param name="objHajjHome"></param>
        public HajjHome createmvcstring(List<HMS.Entities.Models.Advertis> lstAddvertice, HajjHome objHajjHome)
        {
            string strposition1 = string.Empty;
            string strposition2 = string.Empty;
            string strposition3 = string.Empty;
            string strposition4 = string.Empty;
            lstAddvertice.ForEach(delegate(HMS.Entities.Models.Advertis advertise)
            {
                string Addlocation = utility.utility.AdverticeTemplate.Replace("[cposition]", "AddClass")
                        .Replace("[imglocation]", "/binaryObj/" + advertise.AdvertiseId.ToString() + advertise.Name + advertise.Extension).Replace("[pposition]", "Description").Replace("[hposition]", "#").Replace("[tposition]", "tposition");
                if (advertise.AdvertisePositionsId == 1 && advertise.AdvertiseTypeId==1)
                {
                    strposition1 += Addlocation;
                }
                else if (advertise.AdvertisePositionsId == 1 && advertise.AdvertiseTypeId == 2)
                {
                    strposition1 += advertise.AdvertiseContent;
                }

                if (advertise.AdvertisePositionsId == 2 && advertise.AdvertiseTypeId == 1)
                {
                    strposition2 += Addlocation;
                }
                else if (advertise.AdvertisePositionsId == 2 && advertise.AdvertiseTypeId == 2)
                {
                    strposition2 += advertise.AdvertiseContent;
                }

                if (advertise.AdvertisePositionsId == 3 && advertise.AdvertiseTypeId == 1)
                {
                    strposition3 += Addlocation;
                }
                else if (advertise.AdvertisePositionsId == 3 && advertise.AdvertiseTypeId == 2)
                {
                    strposition3 += advertise.AdvertiseContent;
                }

                if (advertise.AdvertisePositionsId == 4 && advertise.AdvertiseTypeId == 1)
                {
                    strposition4 += Addlocation;
                }
                else if (advertise.AdvertisePositionsId == 4 && advertise.AdvertiseTypeId == 2)
                {
                    strposition4 += advertise.AdvertiseContent;
                }

            });
            objHajjHome.position1 = MvcHtmlString.Create(utility.utility.CrusarTemplate.Replace("[itemTemplate]", strposition1).Replace("[position]", "position1"));
            objHajjHome.position2 = MvcHtmlString.Create(utility.utility.CrusarTemplate.Replace("[itemTemplate]", strposition2).Replace("[position]", "position2"));
            objHajjHome.position3 = MvcHtmlString.Create(utility.utility.CrusarTemplate.Replace("[itemTemplate]", strposition3).Replace("[position]", "position3"));
            objHajjHome.position4 = MvcHtmlString.Create(utility.utility.CrusarTemplate.Replace("[itemTemplate]", strposition4).Replace("[position]", "position4"));

            return objHajjHome;
        }

        public void AppImage()
        {
            HMSContext _contex = new HMSContext();
            List<binaryObject> lstbinaryObject = _contex.binaryObjects
                .Where(x => x.ObjectTypeId == 4 || x.ObjectTypeId == 6 || x.ObjectTypeId == 1)
                .ToList();

            string filePathTemplate = System.Web.HttpContext.Current.Server.MapPath("~/binaryObj/")
                + "\\[imagename]" + "[extenssion]";

            lstbinaryObject.ForEach(delegate(binaryObject item)
            {
                string filePath = filePathTemplate.Replace("[imagename]", item.Id.ToString() + item.Name).Replace("[extenssion]", item.Extension);
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.WriteAllBytes(filePath, item.Object);
                }
            });
        }
    }
}