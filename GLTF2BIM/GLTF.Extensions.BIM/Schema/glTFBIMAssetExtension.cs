using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using GLTF2BIM.GLTF.Extensions.BIM.BaseTypes;
using GLTF2BIM.GLTF.Extensions.BIM.Containers;
using Newtonsoft.Json.Serialization;

namespace GLTF2BIM.GLTF.Extensions.BIM.Schema {
    [Serializable]
    public abstract class glTFBIMAssetExtension : glTFBIMExtension {
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }
        
        [JsonProperty("application", Order = 2)]
        public virtual string App { get; set; }

        [JsonProperty("title", Order = 3)]
        public virtual string Title { get; set; }

        [JsonProperty("source", Order = 4)]
        public virtual string Source { get; set; }

        [JsonProperty("levels", Order = 5)]
        public virtual List<uint> Levels { get; set; }

        [JsonProperty("grids", Order = 6)]
        public virtual List<uint> Grids { get; set; }

        [JsonProperty("bounds", Order = 7)]
        public virtual glTFBIMBounds Bounds { get; set; }

        [JsonProperty("containers", Order = 8)]
        public virtual List<glTFBIMPropertyContainer> Containers { get; set; }

        [JsonProperty("properties", Order = 9)]
        public virtual Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        
        [JsonProperty("buckets", Order = 10)]
        public virtual List<Bucket> Buckets { get; set; }

        /// <summary>
        /// World-space origin (glTF axes, meters, double precision) that was subtracted
        /// from every node translation and bounds value in this file at export time.
        /// Absolute/georeferenced coordinates = exported values + originOffset. Null or
        /// absent means the file was not rebased (legacy exports).
        /// </summary>
        [JsonProperty("originOffset", Order = 11)]
        public virtual double[] OriginOffset { get; set; }
    }
}
