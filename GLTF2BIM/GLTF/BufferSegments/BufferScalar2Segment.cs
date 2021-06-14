using System;
using System.Linq;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.GLTF.BufferSegments.BaseTypes;

namespace GLTF2BIM.GLTF.BufferSegments {
    class BufferScalar2Segment : BufferSegment<ushort> {
        public override glTFAccessorType Type => glTFAccessorType.SCALAR;
        public override glTFAccessorComponentType DataType => glTFAccessorComponentType.UNSIGNED_SHORT;
        public override glTFBufferViewTargets Target => glTFBufferViewTargets.ELEMENT_ARRAY_BUFFER;

        public BufferScalar2Segment(ushort[] scalars) {
            Data = scalars;
            _min = new ushort[] { Data.Min() };
            _max = new ushort[] { Data.Max() };
        }
    }
}