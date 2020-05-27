using System;
using System.Collections.Generic;

namespace OnlineShoppingApp.UI.ModelMetadata.Filters
{
    public class TextAreaByNameFilter : IModelMetadataFilter
    {
        private readonly HashSet<string> TextAreaFieldName = new HashSet<string>() { "body", "comments", "description" };
        public void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes)
        {
            if(!string.IsNullOrEmpty(modelMetadata.PropertyName) && string.IsNullOrEmpty(modelMetadata.DataTypeName) &&
                TextAreaFieldName.Contains(modelMetadata.PropertyName.ToLower()))
            {
                modelMetadata.DataTypeName = "MultilineText";
            }
        }
    }
}