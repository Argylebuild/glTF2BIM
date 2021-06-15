using System;
using System.Collections.Generic;
using System.Linq;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.GLTF.BufferSegments.BaseTypes;

namespace GLTF2BIM.GLTF {
    public sealed partial class GLTFBuilder {
        string _name;
        readonly glTF _gltf = null;

        readonly List<BufferSegment> _bufferSegments = new List<BufferSegment>();
        readonly Queue<glTFMeshPrimitive> _primQueue = new Queue<glTFMeshPrimitive>();
    }
}
