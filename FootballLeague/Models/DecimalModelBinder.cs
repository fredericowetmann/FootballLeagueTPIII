using System;
using System.Globalization;
using System.Web.Mvc;

public class DecimalModelBinder : IModelBinder
{
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        // Substituindo vírgula por ponto para garantir que o modelo aceite a vírgula
        value = value.Replace(",", ".");

        // Tenta converter para decimal
        decimal result;
        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
        {
            return result;
        }

        bindingContext.ModelState.AddModelError(bindingContext.ModelName, "O campo deve ser um número válido.");
        return null;
    }
}

