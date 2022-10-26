#pragma checksum "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\LoaiMayBay\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcc29d557a98d356884fb95a4e58ca48270a080e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LoaiMayBay_Index), @"mvc.1.0.view", @"/Views/LoaiMayBay/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc29d557a98d356884fb95a4e58ca48270a080e", @"/Views/LoaiMayBay/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8397e075889cc8e6fdb62ad6a6eb9a268eb36c8c", @"/Views/_ViewImports.cshtml")]
    public class Views_LoaiMayBay_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\ASp_Net\QuanLyChuyenBay\QuanLyCB\DoAnQuanLyChuyenBay\CBBApplication\Views\LoaiMayBay\Index.cshtml"
  
    ViewData["Title"] = "Loại máy bay";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <button id=""themloaimayb"" type=""button"" style=""margin-bottom:10px"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#themloaimaybay"" data-backdrop=""false"">Thêm loại máy bay</button>
        <div class=""table-responsive table--no-card m-b-30"">

            <table class=""table table-borderless table-striped table-earning"">

                <thead>
                    <tr>
                        <th>
                            Ma Loai
                        </th>
                        <th style=""text-align:center"">
                            Hang san xuat
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id=""getdataloadimaybay"">
");
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>

<div id=""themloaimaybay"" class=""modal fade"">
    <div class=""modal-dialog"">

        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <h4 class=""modal-title text-center"">Thêm loại máy bay</h4>

            </div>
            <div class=""modal-body"">
                <div class=""card-body"">
                    <div class=""form-group has-success"">
                        <label for=""cc-name"" class=""control-label mb-1"">Mã Loại</label>
                        <input id=""maloai"" name=""maloai"" type=""text"" class=""form-control cc-name valid""");
            BeginWriteAttribute("value", " value=\"", 2320, "\"", 2328, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""form-group"">
                        <label for=""cc-number"" class=""control-label mb-1"">Hãng san xuất</label>
                        <input id=""hangsanxuat"" name=""hangsanxuat"" type=""tel"" class=""form-control cc-number identified visa""");
            BeginWriteAttribute("value", " value=\"", 2627, "\"", 2635, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button id=""addLoaiMaybay"" type=""button"" class=""btn btn-primary"">Thêm</button>
            </div>
        </div>

    </div>
</div>

<div id=""editloaimaybay"" class=""modal fade"">
    <div class=""modal-dialog"">

        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <h4 class=""modal-title text-center"">Sửa loại máy bay</h4>

            </div>
            <div class=""modal-body"">
                <div class=""card-body"">
                    <div class=""form-group has-success"">
                        <label for=""cc-name"" class=""control-label mb-1"">Mã Loại</label>
                        <input id=""editmaloai"" name=""maloai"" type=""text"" class=""form-control cc-name valid""");
            BeginWriteAttribute("value", " value=\"", 3638, "\"", 3646, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                    </div>
                    <div class=""form-group"">
                        <label for=""cc-number"" class=""control-label mb-1"">Hãng san xuất</label>
                        <input id=""edithangsanxuat"" name=""hangsanxuat"" type=""tel"" class=""form-control cc-number identified visa""");
            BeginWriteAttribute("value", " value=\"", 3958, "\"", 3966, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button id=""editSaveLoaiMaybay"" type=""button"" class=""btn btn-primary"">Sửa</button>
            </div>
        </div>

    </div>
</div>



<script src=""http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"" type=""text/javascript""></script>
<script type=""text/javascript"">
    $(document).ready(function () {
        var url = ""http://localhost:50947/api/"";
        PostData();
        function PostData() {
            $.ajax({
                type: ""GET"",
                url: url + ""LoaiMayBay"",
                //data: answerList,
                //dataType: 'json',
                data: $(""#getdataloadimaybay"").serialize(),
                success: function (data) {
                    $.each(data, function (index, value) {
                        $(""");
            WriteLiteral(@"#getdataloadimaybay"").append(productBuildTableRow(value));
                    });
                },
                error: function () { alert('error'); }
            });
        }
        function productBuildTableRow(product) {
            var ret =
                    '<tr>'
                        + '<td>' + product.maLoai + '</td>'
                        + '<td style=""text-align:center"">' + product.hangSanXuat + '</td>'
                        + '<td style=""float:right"">'
                + '<button type=""button"" style=""margin-right: 10px;"" data-id=""' + product.maLoai + '"" class=""btn btn-primary btn-sm filldataedit"" data-toggle=""modal"" data-target=""#editloaimaybay"" data-backdrop=""false"">Edit</button>'
                + '<button type=""button"" data-id=""' + product.maLoai + '"" class=""btn btn-danger btn-sm deleteloaimaybay"" data-toggle=""modal"" data-target=""#deleteloaimaybay"" data-backdrop=""false"">Delete</button>'
                        +'</td>'
                + '</tr>';
             
   ");
            WriteLiteral(@"         return ret;
        }


        $(""#addLoaiMaybay"").click(function () {

            if ($(""#maloai"").val() == """" || $(""#hangsanxuat"").val() == """") {
                //$.toast('Toast message to be shown');
                $.toast({
                    text: ""Mã loại hoặc hãng sản xuất không được rỗng"",
                    showHideTransition: 'slide',  // It can be plain, fade or slide
                    bgColor: 'red',              // Background color for toast
                    textColor: '#eee',            // text color
                    allowToastClose: false,       // Show the close button or not
                    hideAfter: 5000,              // `false` to make it sticky or time in miliseconds to hide after
                    stack: 5,                     // `fakse` to show one stack at a time count showing the number of toasts that can be shown at once
                    textAlign: 'right',            // Alignment of text i.e. left, right, center
                    po");
            WriteLiteral(@"sition: 'top-right'       // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values to position the toast on page
                })
                $('#themloaimaybay').modal().hide();
            }
            else {
                var loaiMayBay = new Object();
                loaiMayBay.Maloai = $(""#maloai"").val();
               
                //if (maLoai == null) {
                //    return ""Ban Chua Nhap Ma laoi May Bay"" 
                //}
                loaiMayBay.HangSanXuat = $(""#hangsanxuat"").val();
                $.ajax(
                    {
                        type: ""POST"",
                        dataType: 'json',
                        contentType: ""application/json; charset=utf-8"",
                        url: url + ""LoaiMayBay"",
                        data: JSON.stringify(loaiMayBay),

                        success: function () {
                   ");
            WriteLiteral(@"         location.reload();
                            $('#themloaimaybay').modal().hide();
                        },
                        failure: function (response) {
                            //
                        }

                    });
            }
        });  

        $(document).on('click', '.deleteloaimaybay', function () {
            var maloai = $(this).data('id');
            $.ajax({
                url: url + ""LoaiMayBay/"" + maloai,
                type: ""DELETE"",
                contentType: ""application/json;charset=UTF-8"",
                dataType: ""json"",
                success: function (result) {
                    location.reload();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        });
        $(document).on('click', '.filldataedit', function () {
            var maloai = $(this).data('id');
            $.ajax({
               ");
            WriteLiteral(@" url: url + ""LoaiMayBay/"" + maloai,
                type: ""GET"",
                contentType: ""application/json;charset=UTF-8"",
                dataType: ""json"",
                success: function (result) {
                    $('#editmaloai').val(result.maLoai);
                    $('#edithangsanxuat').val(result.hangSanXuat);
                    $('#editloaimaybay').modal('show');
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        });

        $(""#editSaveLoaiMaybay"").click(function () {

            if ($(""#edithangsanxuat"").val() == """") {
                //$.toast('Toast message to be shown');
                $.toast({
                    text: ""hãng sản xuất không được rỗng"",
                    showHideTransition: 'slide',  // It can be plain, fade or slide
                    bgColor: 'red',              // Background color for toast
                    textColor: '#e");
            WriteLiteral(@"ee',            // text color
                    allowToastClose: false,       // Show the close button or not
                    hideAfter: 5000,              // `false` to make it sticky or time in miliseconds to hide after
                    stack: 5,                     // `fakse` to show one stack at a time count showing the number of toasts that can be shown at once
                    textAlign: 'right',            // Alignment of text i.e. left, right, center
                    position: 'top-right'       // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values to position the toast on page
                })
                $('#editloaimaybay').modal().hide();
            }
            else {
                var loaiMayBay = new Object();
                loaiMayBay.Maloai = $(""#editmaloai"").val();
                loaiMayBay.HangSanXuat = $(""#edithangsanxuat"").val();
             ");
            WriteLiteral(@"   var maloai = $(""#editmaloai"").val();
                $.ajax(
                    {
                        type: ""PUT"",
                        dataType: 'json',
                        contentType: ""application/json; charset=utf-8"",
                        url: url + ""LoaiMayBay/"" + maloai,
                        data: JSON.stringify(loaiMayBay),

                        success: function () {
                            location.reload();
                            $('#editloaimaybay').modal().hide();
                        },
                        failure: function (response) {
                            //
                        }

                    });
            }
        }); 

        $(""#themloaimayb"").click(function () {
            $(""#maloai"").val("""");
            $(""#hangsanxuat"").val("""");
        });
    })
</script>
");
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
