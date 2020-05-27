using System;
using System.Collections.Generic;

namespace OnlineShoppingApp.UI.ModelMetadata.Filters
{
    public class ReadOnlyTemplateSelectorFilter : IModelMetadataFilter
    {
        public void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes)
        {
            if(modelMetadata.IsReadOnly && string.IsNullOrEmpty(modelMetadata.DataTypeName))
            {
                modelMetadata.DataTypeName = "ReadOnly";
            }
        }
    }
}