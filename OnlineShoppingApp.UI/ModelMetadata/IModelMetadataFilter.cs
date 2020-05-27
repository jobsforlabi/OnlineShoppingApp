using System;
using System.Collections.Generic;

namespace OnlineShoppingApp.UI.ModelMetadata
{
    public interface IModelMetadataFilter
    {
        void TransformMetada(System.Web.Mvc.ModelMetadata modelMetadata, IEnumerable<Attribute> attributes);
    }
}