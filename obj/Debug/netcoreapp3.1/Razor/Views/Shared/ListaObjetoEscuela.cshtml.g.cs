#pragma checksum "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7e40c659a4576f244fa6eeb05ce362a8d9a90f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ListaObjetoEscuela), @"mvc.1.0.view", @"/Views/Shared/ListaObjetoEscuela.cshtml")]
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
#line 1 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\_ViewImports.cshtml"
using Dotnet_ASP.NET;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\_ViewImports.cshtml"
using Dotnet_ASP.NET.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7e40c659a4576f244fa6eeb05ce362a8d9a90f4", @"/Views/Shared/ListaObjetoEscuela.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7ec39cc004f3c2f759da581919442611dbdbbab", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ListaObjetoEscuela : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table>
    <thead class=""table table-dark table-hover"">
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">Nombre</th>
            <th scope=""col""></th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
         foreach (var obj in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
               Write(obj.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
               Write(obj.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
               Write(Html.ActionLink("Editar", "Edit", new { id = obj.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
               Write(Html.ActionLink("Eliminar", "Delete", new { id = obj.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Rodrigo\Documents\Dotnet ASP.NET\Views\Shared\ListaObjetoEscuela.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
