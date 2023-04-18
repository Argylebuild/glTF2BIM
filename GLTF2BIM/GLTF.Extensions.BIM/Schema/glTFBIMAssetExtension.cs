using System;
using System.Collections.Generic;
using System.Numerics;
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
        public virtual Dictionary<string, object> Properties { get; set; }
        
        [JsonProperty("buckets", Order = 10)]
        public virtual List<Bucket> Buckets { get; set; }
    }

    public abstract class Bucket
    {
        /// <summary>
        /// Simple name describing this collection. 
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public virtual string Name { get; set; }
        /// <summary>
        /// A more detailed description of this collection.
        /// </summary>
        [JsonProperty("description", Order = 2)]
        public virtual string Description { get; set; }
        /// <summary>
        /// All elements in this collection will display this color in the AR viewer.
        /// User may also apply colors to view in authoring software. 
        /// </summary>
        [JsonProperty("color", Order = 3)]
        public virtual Vector3 Color { get; set; }
        /// <summary>
        /// If true, when app opens this project, everything in the collection will be visible
        /// as long as other requirements are met. (E.G. Link is on and in range)
        /// </summary>
        [JsonProperty("isVisibleAtStart", Order = 4)]
        public virtual bool IsVisibleAtStart { get; set; }
        /// <summary>
        /// The minature view doesn't need to show everything in the model but only what is helpful for navigation.
        /// Core and shell, structure, floors, and walls are all recommended. 
        /// </summary>
        [JsonProperty("isIncludedInDollhouse", Order = 5)]
        public virtual bool IsIncludedInDollhouse { get; set; }
        /// <summary>
        /// For visual simplicity, it is helpful for some elements to hide elements behind them.
        /// Walls, floors, Roofs and sometimes ceilings are good candidates for occlusion.
        /// </summary>
        [JsonProperty("isOccluding", Order = 6)]
        public virtual bool IsOccluding { get; set; }
        /// <summary>
        /// Most small elements are only rendered when the user is close to them.
        /// Large elements that are critical for navigation should be rendered at all times.
        /// Floors or Core and Shell, for example should be set to false. 
        /// </summary>
        [JsonProperty("isProximityBased", Order = 7)]
        public virtual bool IsProximityBased { get; set; }

        protected Bucket(string name)
        {
            Name = name;
            

        }

        /// <summary>
        /// This constructor is only used for deserialization.
        /// </summary>
        protected Bucket() { }

    }
}
