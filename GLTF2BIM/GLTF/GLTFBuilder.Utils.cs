using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.Properties;
using GLTF2BIM.GLTF.BufferSegments;
using GLTF2BIM.GLTF.Package;

namespace GLTF2BIM.GLTF {
    sealed partial class GLTFBuilder {
        uint AppendNodeToScene(uint idx) {
            if (PeekScene() is glTFScene scene) {
                if (!_gltf.Nodes.IsOpen())
                    scene.Nodes.Add(idx);
                return idx;
            }
            else
                throw new Exception(StringLib.NoParentScene);
        }
    }
}
