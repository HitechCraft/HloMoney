using System.Text.RegularExpressions;

namespace System.Web.Mvc
{
    using Html;

    public static class HtmlHelperExtentions
    {
        public static MvcHtmlString ValidationSummaryStyled(this HtmlHelper html, bool excludePropertyErrors)
        {
            var summary = html.ValidationSummary(excludePropertyErrors);

            return summary != null && !Regex.IsMatch(summary.ToString(), "validation-summary-valid") && summary != new MvcHtmlString("") ? new MvcHtmlString(" <div class='alert alert-danger validation'>" +
                                     "<h4>Обнаружены ошибки:</h4>" +
                                     summary +
                                     "</div>") : new MvcHtmlString("");
        }
    }
}