﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GLTF2BIM.GLTF.Schema {
    /// <summary>
    /// The json serializable glTF file format.
    /// </summary>
    // https://github.com/KhronosGroup/glTF/tree/master/specification/2.0
    [Serializable]
    public sealed class glTF {
        [JsonProperty("asset")]
        public glTFAsset Asset { get; set; } = null;

        [JsonProperty("extensionsUsed")]
        public HashSet<string> ExtensionsUsed { get; set; }

        [JsonProperty("scenes")]
        public List<glTFScene> Scenes { get; set; } = new List<glTFScene>();

        [JsonProperty("scene")]
        public uint StartingScene { get; set; } = 0;

        [JsonProperty("nodes")]
        public glTFNodes Nodes { get; set; } = new glTFNodes();

        [JsonProperty("meshes")]
        public List<glTFMesh> Meshes { get; set; } = new List<glTFMesh>();

        [JsonProperty("accessors")]
        public List<glTFAccessor> Accessors { get; set; } = new List<glTFAccessor>();

        [JsonProperty("bufferViews")]
        public List<glTFBufferView> BufferViews { get; set; } = new List<glTFBufferView>();

        [JsonProperty("buffers")]
        public List<glTFBuffer> Buffers { get; set; } = new List<glTFBuffer>();

        [JsonProperty("materials")]
        public List<glTFMaterial> Materials { get; set; } = null;
    }
}
