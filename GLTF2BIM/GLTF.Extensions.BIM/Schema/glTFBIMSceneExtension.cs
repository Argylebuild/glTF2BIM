using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

using Newtonsoft.Json;

using GLTF2BIM.GLTF.Extensions.BIM.BaseTypes;
namespace GLTF2BIM.GLTF.Extensions.BIM.Schema {
    public abstract class glTFBIMSceneExtension : glTFBIMExtension {
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty("taxonomies", Order = 2)]
        public virtual List<string> Taxonomies { get; set; } = new List<string>();

        [JsonProperty("description", Order = 3)]
        public virtual string Description { get; set; }

        [JsonProperty("comment", Order = 4)]
        public virtual string Comment { get; set; }

        [JsonProperty("imageUrl", Order = 9)]
        public virtual string ImageUrl { get; set; }

        [JsonProperty("level", Order = 10)]
        public virtual string Level { get; set; }

        [JsonProperty("bounds", Order = 11)]
        public virtual glTFBIMBounds Bounds { get; set; }

        [JsonProperty("properties", Order = 99)]
        public virtual Dictionary<string, object> Properties { get; set; }
    }
}
