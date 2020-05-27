using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.ModelMetadata
{
    public class ExtensibleModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IModelMetadataFilter[] modelMetadataFilters;

        public ExtensibleModelMetadataProvider(IModelMetadataFilter[] metadataFilters)
        {
            modelMetadataFilters = metadataFilters;
        }

        protected override System.Web.Mvc.ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
                                                                        Type containerType,
                                                                        Func<object> modelAccessor,
                                                                        Type modelType,
                                                                        string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            modelMetadataFilters.ForEach(m => m.TransformMetada(metadata, attributes));
            return metadata;
        }
    }
}