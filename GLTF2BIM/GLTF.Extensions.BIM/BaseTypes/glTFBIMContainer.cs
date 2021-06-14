using System;

using Newtonsoft.Json;

namespace GLTF2BIM.GLTF.Extensions.BIM.BaseTypes {
    [Serializable]
    abstract class glTFBIMContainer {
        [JsonProperty("$type")]
        public abstract string Type { get; }

        [JsonProperty("uri")]
        public abstract string Uri { get; }
    }
}
