using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.utility
{

    public enum binaryObjectTypes
    {
        Application = 1
            ,
        Advertise = 2
            ,
        Hotel = 3
            ,
        PackageSource = 4
           ,
        DefaultAdvertise = 5
            ,
        EventLogo = 6
            ,
        News = 7
            ,
        EventDoc = 8
            ,
        AgentLogo = 9
            ,
        PackageLeaflet = 10
        ,
        Scholare=11


    };

    public enum PageType
    {
        HomePage = 1
            ,
        Information = 2
            ,
        NewsAndEvents = 3
    };

    public enum UserInfoType
    {

    };

    public enum ErrorCode
    {
        UserSecurity_UserNameExists = 101,
        UserSecurity_PasswordNotChanged = 102,
        NoError = 0
    };

    public enum DashBoardColor
    {
        sky = 1
        ,
        orange
            ,
        brown
            ,
        midnightblue
            ,
        purple
            ,
        success
            ,
        primary
            ,
        indigo
            ,
        green
            ,
        danger
            ,
        magenta
        , inverse
    };

    public enum NoticeType
    {
        Student = 11
        ,
        Teacher = 12
        ,
        Employee = 13
    };

    public enum ShortMessageStstus
    {
        Pending = 101
            ,
        Delivered = 102
           ,
        Undelivered = 103
    };

}
