using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ProjectManagement.AspNetMvc.PL.HtmlHelpers
{
    public static class HtmlExtensions
    {
        /*
         *  Called by Partial or View that need to add Scripts to the _layout
         */
        //public static IHtmlString Resource(this HtmlHelper htmlHelper, Func<object, HelperResult> template, string type)
        //{
        //    if (htmlHelper.ViewContext.HttpContext.Items[type] == null)
        //        htmlHelper.ViewContext.HttpContext.Items[type] = new List<Func<object, HelperResult>>();

        //    ((List<Func<object, HelperResult>>)htmlHelper.ViewContext.HttpContext.Items[type]).Add(template);
        //    return new HtmlString(String.Empty);
        //}

        /*
         *  Called by Helper or view that need to add Scripts to the _layout
         */
        //public static MvcHtmlString Resource(this HtmlHelper htmlHelper, string template, string type)
        //{
        //    Func<object, HelperResult> func = delegate (object o)
        //    {
        //        return new HelperResult
        //        (
        //            writer =>
        //            {
        //                writer.Write(template);
        //            }
        //        );
        //    };
        //    Resource(htmlHelper, func, type);
        //    return MvcHtmlString.Empty;
        //}

        /*
         *  Called by the Layout to render scripts from partial/view/htmlHelper, ....
         */
        //public static IHtmlString RenderResources(this HtmlHelper htmlHelper, string type)
        //{
        //    if (htmlHelper.ViewContext.HttpContext.Items[type] != null)
        //    {
        //        List<Func<object, HelperResult>> resources = (List<Func<object, HelperResult>>)htmlHelper.ViewContext.HttpContext.Items[type];

        //        foreach (var resource in resources)
        //        {
        //            if (resource != null) htmlHelper.ViewContext.Writer.Write(resource(null) + Environment.NewLine);
        //        }
        //    }

        //    return new HtmlString(String.Empty);
        //}

        //public static IHtmlString Resource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        //{
        //    if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
        //    else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };

        //    return new HtmlString(String.Empty);
        //}

        //public static IHtmlString RenderResources(this HtmlHelper HtmlHelper, string Type)
        //{
        //    if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
        //    {
        //        List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];

        //        foreach (var Resource in Resources)
        //        {
        //            if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
        //        }
        //    }

        //    return new HtmlString(String.Empty);
        //}
    }
}