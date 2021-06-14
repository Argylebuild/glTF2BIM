using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using GLTF2BIM.GLTF.Extensions.BIM.BaseTypes;
using GLTF2BIM.GLTF.Extensions.BIM.Containers;

namespace GLTF2BIM.GLTF.Extensions.BIM {
    [Serializable]
    class glTFBIMAssetExtension : glTFBIMExtension {
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty("application", Order = 2)]
        public string App { get; set; }

        [JsonProperty("title", Order = 3)]
        public string Title { get; set; }

        [JsonProperty("source", Order = 4)]
        public string Source { get; set; }

        [JsonProperty("levels", Order = 5)]
        public List<uint> Levels { get; set; }

        [JsonProperty("grids", Order = 6)]
        public List<uint> Grids { get; set; }

        [JsonProperty("bounds", Order = 7)]
        public glTFBIMBounds Bounds { get; set; }

        [JsonProperty("containers", Order = 8)]
        public List<glTFBIMPropertyContainer> Containers { get; set; }

        [JsonProperty("properties", Order = 9)]
        public Dictionary<string, object> Properties { get; set; }
    }
}
