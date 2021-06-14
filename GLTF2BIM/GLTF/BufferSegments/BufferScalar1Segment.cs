﻿using System.Linq;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.GLTF.BufferSegments.BaseTypes;

namespace GLTF2BIM.GLTF.BufferSegments {
    class BufferScalar1Segment : BufferSegment<byte> {
        public override glTFAccessorType Type => glTFAccessorType.SCALAR;
        public override glTFAccessorComponentType DataType => glTFAccessorComponentType.UNSIGNED_BYTE;
        public override glTFBufferViewTargets Target => glTFBufferViewTargets.ELEMENT_ARRAY_BUFFER;

        public BufferScalar1Segment(byte[] scalars) {
            Data = scalars;
            _min = new byte[] { Data.Min() };
            _max = new byte[] { Data.Max() };
        }

        public override byte[] ToByteArray() => Data;
    }
}