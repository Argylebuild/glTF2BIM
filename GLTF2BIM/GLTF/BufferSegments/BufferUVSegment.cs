using System;
using System.Collections.Generic;
using System.Linq;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.GLTF.BufferSegments.BaseTypes;

namespace GLTF2BIM.GLTF.BufferSegments {
    class BufferUVSegment : BufferSegment<float> {
        public override glTFAccessorType Type => glTFAccessorType.VEC2;
        public override glTFAccessorComponentType DataType => glTFAccessorComponentType.FLOAT;
        public override glTFBufferViewTargets Target => glTFBufferViewTargets.ARRAY_BUFFER;

        public BufferUVSegment(float[] uvs) {
            if (uvs.Length % 2 != 0)
                throw new Exception("Array data is not UV (VEC2) data");
            Data = uvs;
            SetBounds(Data);
        }

        public override uint Count => (uint)(Data.Length / 2);

        // Base Equals compares raw bytes only; require matching accessor type so a
        // VEC2 segment can never dedup onto a byte-identical VEC3 segment.
        public override bool Equals(object obj) => obj is BufferUVSegment && base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

        void SetBounds(float[] uvs) {
            List<float> u = new List<float>();
            List<float> v = new List<float>();
            for (int i = 0; i < uvs.Length; i += 2) {
                u.Add(uvs[i]);
                v.Add(uvs[i + 1]);
            }

            _min = new float[] { u.Min(), v.Min() };
            _max = new float[] { u.Max(), v.Max() };
        }
    }
}
