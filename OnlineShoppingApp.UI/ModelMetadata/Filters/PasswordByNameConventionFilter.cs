using System;
using System.Collections.Generic;

namespace OnlineShoppingApp.UI.ModelMetadata.Filters
{
    public class PasswordByNameConventionFilter : IModelMetadataFilter
    {
        private readonly HashSet<string> PasswordFieldNames = new HashSet<string>() { "password", "match password"};
        public void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes)
        {
            if(!string.IsNullOrEmpty(modelMetadata.DisplayName) && string.IsNullOrEmpty(modelMetadata.DataTypeName) &&
                    PasswordFieldNames.Contains(modelMetadata.DisplayName.ToLower()))
            {
                modelMetadata.DataTypeName = "Password";
            }
        }
    }
}