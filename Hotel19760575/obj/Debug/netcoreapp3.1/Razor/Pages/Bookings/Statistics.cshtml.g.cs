#pragma checksum "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5934d54eb425ebcc36809a82d9a593afc3ae65e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Hotel19760575.Pages.Bookings.Pages_Bookings_Statistics), @"mvc.1.0.razor-page", @"/Pages/Bookings/Statistics.cshtml")]
namespace Hotel19760575.Pages.Bookings
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\_ViewImports.cshtml"
using Hotel19760575;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\_ViewImports.cshtml"
using Hotel19760575.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5934d54eb425ebcc36809a82d9a593afc3ae65e6", @"/Pages/Bookings/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73105dda818582d02cc1d2fcfb39757d8394ea6a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Bookings_Statistics : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
  
    ViewData["Title"] = "CalcSubscriptionStats";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Statistics</h1>

<br/>

<h2>Customer distribution with respect to postcodes</h2>
<table class=""table"">
        <tr>
            <th>
                Postcode
            </th>
            <th>
                Number of Customers
            </th>
        </tr>
");
#nullable restore
#line 21 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
         foreach (var item in Model.CustomerStatistic)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("  <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 27 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumOfCustomers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 30 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>

<br/>

<h2>""Booking distribution with respect to rooms</h2>
<table class=""table"">
        <tr>
            <th>
                Room ID
            </th>
            <th>
                Number of Bookings
            </th>
        </tr>
        <tr>
");
#nullable restore
#line 46 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
             foreach (var item in Model.BookingStatistic)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.RoomID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumOfBookings));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 56 "C:\Users\aylin\Desktop\Uni Stuffs\Spring 2021\300583 Web Systems Development\Project\Github\Hotel19760575\Pages\Bookings\Statistics.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hotel19760575.Pages.Bookings.StatisticsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotel19760575.Pages.Bookings.StatisticsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotel19760575.Pages.Bookings.StatisticsModel>)PageContext?.ViewData;
        public Hotel19760575.Pages.Bookings.StatisticsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
