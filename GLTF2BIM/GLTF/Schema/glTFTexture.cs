using System;

using Newtonsoft.Json;

namespace GLTF2BIM.GLTF.Schema {
    /// <summary>
    /// A texture referencing an image, assignable to material texture slots.
    /// Sampler is omitted; glTF defaults apply (repeat wrapping, auto filtering).
    /// </summary>
    // https://github.com/KhronosGroup/glTF/tree/master/specification/2.0#textures
    [Serializable]
    public sealed class glTFTexture {
        /// <summary>
        /// The index of the image used by this texture
        /// </summary>
        [JsonProperty("source")]
        public uint Source { get; set; }
    }

    /// <summary>
    /// Image data for textures. Uri carries either an external file
    /// reference or an embedded data URI (data:image/png;base64,...).
    /// </summary>
    // https://github.com/KhronosGroup/glTF/tree/master/specification/2.0#images
    [Serializable]
    public sealed class glTFImage {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
    }

    /// <summary>
    /// Reference from a material to a texture, with the TEXCOORD set index.
    /// </summary>
    // https://github.com/KhronosGroup/glTF/tree/master/specification/2.0#reference-textureinfo
    [Serializable]
    public sealed class glTFTextureInfo {
        /// <summary>
        /// The index of the texture
        /// </summary>
        [JsonProperty("index")]
        public uint Index { get; set; }

        /// <summary>
        /// The set index of texture's TEXCOORD attribute (TEXCOORD_0 = 0)
        /// </summary>
        [JsonProperty("texCoord")]
        public uint TexCoord { get; set; } = 0;
    }
}
