#pragma checksum "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductModalPartial.cshtml")]
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
#line 2 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Interface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.ViewModels.Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.ViewModels.Basket;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99fbd04bf8d8da6da98f58fe9bb43432dd3f2e54", @"/Views/Shared/_ProductModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4548d69949b1e6a13d6f81886e6183e185978e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <div class=\"product-quick-view-image mt-30\">\r\n            <div class=\"quick-view-image\">             \r\n");
#nullable restore
#line 7 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                    foreach (ProductImage productImage in Model.ProductImages)
                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <div class=\"single-view-image\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e546496", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 372, "~/assets/images/product/", 372, 24, true);
#nullable restore
#line 10 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 396, productImage.Name, 396, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                       </div>\r\n");
#nullable restore
#line 12 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                   }     

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <ul class=\"quick-view-thumb\">\r\n");
#nullable restore
#line 15 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                 foreach (ProductImage productImage in Model.ProductImages)
                { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        <div class=\"single-thumb\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e548830", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 766, "~/assets/images/product/", 766, 24, true);
#nullable restore
#line 19 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 790, productImage.Name, 790, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </li>\r\n");
#nullable restore
#line 22 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ul>\r\n        </div> <!-- Modal Quick View Image -->\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <div class=\"product-quick-view-content mt-30\">\r\n            <h3 class=\"product-title\">");
#nullable restore
#line 29 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                 Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            <p class=""reference"">Reference: demo_12</p>
            <ul class=""rating"">
                <li class=""rating-on""><i class=""fas fa-star""></i></li>
                <li class=""rating-on""><i class=""fas fa-star""></i></li>
                <li class=""rating-on""><i class=""fas fa-star""></i></li>
                <li class=""rating-on""><i class=""fas fa-star""></i></li>
                <li class=""rating-on""><i class=""fas fa-star""></i></li>
            </ul>
            <div class=""product-prices"">
                
");
#nullable restore
#line 40 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                 if (Model.DiscountedPrice > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"sale-price\"> €");
#nullable restore
#line 42 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                          Write(Model.Price.ToString("0.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <span class=\"regular-price\">€");
#nullable restore
#line 43 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                            Write(Model.DiscountedPrice.ToString("0.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <span class=\"save\">Save ");
#nullable restore
#line 44 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                        Write((((Model.Price * 100) / Model.DiscountedPrice)-100).ToString("0.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 45 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"

                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"regular-price\"> €");
#nullable restore
#line 49 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                             Write(Model.Price.ToString("0.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 50 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n            <p class=\"product-description\">");
#nullable restore
#line 55 "C:\Users\ACER\Desktop\New folder\WebApplication1\Views\Shared\_ProductModalPartial.cshtml"
                                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"product-size-color flex-wrap\">\r\n                <div class=\"product-size\">\r\n                    <h5 class=\"title\">Size</h5>\r\n                    <select>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e5414497", async() => {
                WriteLiteral("S");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e5415676", async() => {
                WriteLiteral("M");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e5416855", async() => {
                WriteLiteral("L");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99fbd04bf8d8da6da98f58fe9bb43432dd3f2e5418034", async() => {
                WriteLiteral("XL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                </div>
                <div class=""product-color"">
                    <h5 class=""title"">Color</h5>
                    <div class=""color-input"">
                        <div class=""single-color color-1"">
                            <input type=""radio"" id=""radio-1"" name=""color"">
                            <label for=""radio-1""></label>
                        </div>
                        <div class=""single-color color-2"">
                            <input type=""radio"" id=""radio-2"" name=""color"">
                            <label for=""radio-2""></label>
                        </div>
                        <div class=""single-color color-3"">
                            <input type=""radio"" id=""radio-3"" name=""color"">
                            <label for=""radio-3""></label>
                        </div>
                    </div>
                </div>
                <div class=""product-quantity"">
                    <h5 class=""title"">Quanti");
            WriteLiteral(@"ty</h5>
                    <div class=""quantity d-flex"">
                        <button type=""button"" id=""sub"" class=""sub""><i class=""fal fa-minus""></i></button>
                        <input type=""text"" value=""1"" />
                        <button type=""button"" id=""add"" class=""add""><i class=""fal fa-plus""></i></button>
                    </div>
                </div>
            </div>
            <div class=""product-add-cart"">
                <button><i class=""icon ion-bag""></i> Add to cart</button>
            </div>
            <div class=""product-wishlist-compare"">
                <ul class=""d-flex flex-wrap"">
                    <li><a href=""#""><i class=""fal fa-heart""></i> Add to wishlist</a></li>
                    <li><a href=""#""><i class=""fal fa-repeat""></i> Add to compare</a></li>
                </ul>
            </div>
            <div class=""product-share d-flex"">
                <p>Share</p>
                <ul class=""social media-body"">
                    <li><a href=""#""");
            WriteLiteral(@"><i class=""fab fa-facebook-f""></i></a></li>
                    <li><a href=""#""><i class=""fab fa-twitter""></i></a></li>
                    <li><a href=""#""><i class=""fab fa-google""></i></a></li>
                    <li><a href=""#""><i class=""fab fa-pinterest-p""></i></a></li>
                </ul>
            </div>
        </div> <!-- Modal Quick View Content -->
    </div>
</div> <!-- row -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
