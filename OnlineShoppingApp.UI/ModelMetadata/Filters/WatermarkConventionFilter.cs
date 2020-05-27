using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingApp.UI.ModelMetadata.Filters
{
    public class WatermarkConventionFilter : IModelMetadataFilter
    {
        public void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes)
        {
            if(!string.IsNullOrEmpty(modelMetadata.DisplayName) && string.IsNullOrEmpty(modelMetadata.Watermark))
            {
                modelMetadata.Watermark = modelMetadata.DisplayName + "...";
            }
        }
    }
}