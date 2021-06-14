using System;

using GLTF2BIM.Properties;
using GLTF2BIM.GLTF.Schema;

namespace GLTF2BIM.GLTF.Extensions.BIM.BaseTypes {
    [Serializable]
    public abstract class glTFBIMExtension: glTFExtension {
        public override string Name => StringLib.GLTFExtensionName;
    }
}
