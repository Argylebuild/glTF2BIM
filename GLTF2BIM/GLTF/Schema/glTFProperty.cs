using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using GLTF2BIM.Properties;

namespace GLTF2BIM.GLTF.Schema {
    [Serializable]
    abstract class glTFProperty {
        [JsonProperty("extensions")]
        public Dictionary<string, glTFExtension> Extensions { get; set; }

        [JsonProperty("extras")]
        public glTFExtras Extras { get; set; }
    }
}
