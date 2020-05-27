using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OnlineShoppingApp.UI.ModelMetadata.Filters
{
    public class LabelConventionFilter : IModelMetadataFilter
    {
        public void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes)
        {
            if(!string.IsNullOrEmpty(modelMetadata.PropertyName) && string.IsNullOrEmpty(modelMetadata.DisplayName))
            {
                modelMetadata.DisplayName = GetStringWithSpaces(modelMetadata.PropertyName);
            }
        }

        private string GetStringWithSpaces(string propertyName)
        {
            return Regex.Replace(propertyName, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.IgnorePatternWhitespace);
        }
    }
}