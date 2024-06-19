using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace JobSearch.WEB.Middlewares.ExtensionHelpers
{
    public class KebabCaseControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel.Template = TransformToKebabCase(selector.AttributeRouteModel.Template);
                }
            }
        }

        private string TransformToKebabCase(string template)
        {
            return Regex.Replace(template, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
