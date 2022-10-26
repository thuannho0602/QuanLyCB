#pragma checksum "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\DoanhThuThang\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdf4afaeb52247cc8c119eb51f152ed3848cd93b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DoanhThuThang_Index), @"mvc.1.0.view", @"/Views/DoanhThuThang/Index.cshtml")]
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
#line 1 "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\_ViewImports.cshtml"
using CBBApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\_ViewImports.cshtml"
using CBBApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf4afaeb52247cc8c119eb51f152ed3848cd93b", @"/Views/DoanhThuThang/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8397e075889cc8e6fdb62ad6a6eb9a268eb36c8c", @"/Views/_ViewImports.cshtml")]
    public class Views_DoanhThuThang_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\DoanhThuThang\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""table-responsive table--no-card m-b-30"">

            <table class=""table table-borderless table-striped table-earning"">

                <thead>
                    <tr>
                        <th>
                            Tên máy bay
                        </th>
                        <th>
                            Doanh Thu
                        </th>
                        <th>
                            Số Vé
                        </th>
                    </tr>
                </thead>
                <tbody id=""getdatadoanhthuthang"">
                </tbody>
            </table>
        </div>
    </div>
</div>


<script src=""http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"" type=""text/javascript""></script>
<script type=""text/javascript"">
    $(document).ready(function () {
        var url = ""http://localhost:50947/api/"";
        GetData();
        function GetData() {
     ");
            WriteLiteral(@"       var date = new Date();
            var thang = date.getMonth() + 1;
            $.ajax({
                type: ""POST"",
                url: url + ""DatChoHanhKhach/GetBaoCaoDanhThuTheoThang/"" + thang,
                data: $(""#getdatadoanhthuthang"").serialize(),
                success: function (data) {
                    $.each(data, function (index, value) {
                        $(""#getdatadoanhthuthang"").append(productBuildTableRow(value));
                    });
                },
                error: function () { alert('error'); }
            });
        }
        function productBuildTableRow(item) {
            var ret =
                '<tr>'
                + '<td>' + item.tenMayBay + '</td>'
                + '<td>' + item.doanhThu + '</td>'
                + '<td>' + item.soVe + '</td>'
                + '</tr>';

            return ret;
        }
    })

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
