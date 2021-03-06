#pragma checksum "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dafa1a8d949d7ee8c3270bd1b4edb9f3a24c16db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sales_Add), @"mvc.1.0.view", @"/Views/Sales/Add.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Dell\source\repos\CustomerSales\Views\_ViewImports.cshtml"
using CustomerSales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\source\repos\CustomerSales\Views\_ViewImports.cshtml"
using CustomerSales.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dafa1a8d949d7ee8c3270bd1b4edb9f3a24c16db", @"/Views/Sales/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f5ebc7b16531a1eca1a3622b30fd0bb79b65f78", @"/Views/_ViewImports.cshtml")]
    public class Views_Sales_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerSales.ViewModel.SalesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
  
    ViewData["Title"] = "Add";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Add</h1>\r\n");
#nullable restore
#line 8 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <div>\r\n            <label>Sales No</label>\r\n            <input type=\"text\" id=\"SalesNo\" class=\"form-control\" placeholder=\"0\" />\r\n        </div>\r\n        <td>\r\n            ");
#nullable restore
#line 16 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
       Write(Html.DropDownList("Customer", (IEnumerable<SelectListItem>)ViewBag.Customer,
           "Select Item", new { @class = "form-control m-input", @id = "CustomerId", }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </td>

        <div>
            <table class=""table"" id=""AddItem"">
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Quantity</th>
                        <th>per Price</th>
                        <th>Total Price</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>

                        <td>
                            ");
#nullable restore
#line 36 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
                       Write(Html.DropDownList("Items", (IEnumerable<SelectListItem>)ViewBag.Items,
                           "Select Item", new { @class = "form-control m-input", @id = "ItemId", @onchange = "GetItemPrice()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </td>
                        <td>
                            <input type=""text"" id=""Quantity"" class=""form-control m-input"" placeholder=""0"" onkeyup=""Multitpy()"" />
                        </td>
                        <td>
                            <input type=""text"" id=""ItemPrice"" class=""form-control m-input"" placeholder=""0"" readonly />
                        </td>
                        <td>
                            <input type=""text"" id=""TotalPrice"" class=""form-control m-input"" placeholder=""0"" readonly />
                        </td>
                        <td>
                            <a onclick=""PushSalesItem();"">
                                Add
                            </a>
                        </td>
                    </tr>
                </tbody>
            </table>

        </div>
        <div>
            <label>Gross Amount</label>
            <input type=""text"" id=""NetAmount"" class=""form-control"" placeholder=""0"" readonly /");
            WriteLiteral(@">

        </div>
        <div>
            <label>Discount Amount</label>
            <input type=""text"" id=""Discount"" class=""form-control"" placeholder=""0"" onkeyup=""GetDiscountedAmount()"" />
        </div>
        <div>
            <label>Total Amount</label>
            <input type=""text"" id=""TotalSales"" class=""form-control"" placeholder=""0"" readonly />
        </div>
        <br />
        <div>
            <a onclick=""saveData()"" class=""btn btn-success"">
");
#nullable restore
#line 75 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
                 if (Model.Master.Id == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Add</span>\r\n");
#nullable restore
#line 78 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Update</span>\r\n");
#nullable restore
#line 82 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </a>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=\"", 3041, "\"", 3076, 1);
#nullable restore
#line 87 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
WriteAttributeValue("", 3048, Url.Action("Index","Sales"), 3048, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Back</a>\r\n");
#nullable restore
#line 88 "C:\Users\Dell\source\repos\CustomerSales\Views\Sales\Add.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src="" https://cdnjs.cloudflare.com/ajax/libs/knockout/3.5.1/knockout-latest.js""></script>
    <script type=""text/javascript"">
        var QuantityinStock = 0;
        var SalesDetails = [];
        function GetItemPrice() {
            var itemId = $(""#ItemId"").val();
            $.getJSON(""/Sales/GetItem?id="" + itemId, function (result) {
                $(""#ItemPrice"").val(result.price);
                QuantityinStock = result.quantity;
            });
        }

        //function GetCustomer() {
        //    var customerId = $(""#CustomerId"").val();
        //    $.getJSON(""/Sales/GetCustomer?id="" + customerId, function (result) {
        //        $(""#CustomerName"").val(result.name);
        //    });
        //}
        function Multitpy() {
            var Quantity = $(""#Quantity"").val();
            var ItemPrice = $(""#ItemPrice"").val();
            var TotalPrice = (Quantity * ItemPrice);
            $(""#TotalPrice"").val(TotalPrice);
        }

        function");
                WriteLiteral(@" SalesDetailsModel(item) {
            var self = this;
            item = item || {};
            self.ItemId = ko.observable(item.ItemId || 0);
            self.Quantity = ko.observable(item.Quantity || 0);
            self.ItemPrice = ko.observable(item.ItemPrice || 0);
            self.TotalPrice = ko.observable(item.TotalPrice || 0);
        }
        var self = this;
        self.sales = ko.observable();
        self.SalesList = ko.observableArray([]);

        function PushSalesItem() {

            var itemId = $(""#ItemId"").val();
            if (itemId == 0 || itemId == undefined) {
                return alert(""Select Item"");
            }
            var Quantity = $(""#Quantity"").val();
            var ItemPrice = $(""#ItemPrice"").val();
            var TotalPrice = $(""#TotalPrice"").val();
            var ItemName = $(""#ItemId option:selected"").text();
            var tr = $(`<tr> <td> ${ItemName}</td>
                    <td> ${Quantity} </td>
                    <td> ${Item");
                WriteLiteral(@"Price} </td>
                    <td> ${TotalPrice}</td>
                    <td> <a id=""DeleteButton""> Delete</a></td></tr>`);
            $('#AddItem').append(tr);
            self.SalesList.push(ko.toJS(new SalesDetailsModel(
                {
                    ItemId: itemId,
                    Quantity: Quantity,
                    ItemPrice: ItemPrice,
                    TotalPrice: TotalPrice
                })));
            GetTotalAmount();
            $(""#ItemId"").val("""");
            $(""#Quantity"").val("""");
            $(""#ItemPrice"").val("""");
            $(""#TotalPrice"").val("""");
        }
        function GetTotalAmount() {
            debugger;
            var amount = 0;
            for (var i = 0; i < self.SalesList().length; i++) {
                //amount = amount + self.SalesList()[i].TotalPrice;
                amount += parseFloat(self.SalesList()[i].TotalPrice);
            }
            $(""#NetAmount"").val(amount);
            $(""#NetAmount"").text(amount);");
                WriteLiteral(@"
            $(""#TotalSales"").val(amount);
            $(""#TotalSales"").text(amount);
        };
        function GetDiscountedAmount() {
            var grossAmount = $(""#NetAmount"").val();
            var discountAmount = $(""#Discount"").val();
            var amount = grossAmount - discountAmount;
            $(""#TotalSales"").val(amount);
            $(""#TotalSales"").text(amount);

        }
        $(""#AddItem"").on(""click"", ""#DeleteButton"", function () {
            $(this).closest(""tr"").remove();
        });


        function saveData() {
            debugger;
            if ((self.SalesList().length) == 0) {
                return alert(""Enter Details"");
            }

            var master = {
                SaleNo: $(""#SalesNo"").val(),
                NetAmount: $(""#NetAmount"").val(),
                Discount: $(""#Discount"").val(),
                TotalSales: $(""#TotalSales"").val()
            }
            var data = {
                Master: master,
                D");
                WriteLiteral(@"etails: self.SalesList()
            }
            $.post(""/Sales/SalesPost"", data)
                .done(function (result) {
                    alert('Sales Completed');
                });
            window.location.href = ""/Sales/Index"";
        }


    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerSales.ViewModel.SalesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
