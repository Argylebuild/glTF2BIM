using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using GLTF2BIM.Properties;

namespace GLTF2BIM.GLTF.Schema {
    /// <summary>
    /// Required glTF asset information
    /// https://github.com/KhronosGroup/glTF/tree/master/specification/2.0#asset
    /// </summary>
    [Serializable]
    class glTFAsset : glTFProperty {
        [JsonProperty("version")]
        public string Version = "2.0";

        [JsonProperty("generator")]
        public string Generator = null;

        [JsonProperty("copyright")]
        public string Copyright = null;
    }
}
