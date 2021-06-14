using System;
using System.Collections.Generic;
using System.Linq;

using GLTF2BIM.GLTF.Schema;
using GLTF2BIM.GLTF.BufferSegments.BaseTypes;
using GLTF2BIM.Properties;

namespace GLTF2BIM.GLTF.BufferSegments {
    class BufferVectorSegment : BufferSegment<float> {
        public override glTFAccessorType Type => glTFAccessorType.VEC3;
        public override glTFAccessorComponentType DataType => glTFAccessorComponentType.FLOAT;
        public override glTFBufferViewTargets Target => glTFBufferViewTargets.ARRAY_BUFFER;

        public BufferVectorSegment(float[] vectors) {
            if (vectors.Length % 3 != 0)
                throw new Exception(StringLib.ArrayIsNotVector3Data);
            Data = vectors;
            SetBounds(Data);
        }

        public override uint Count => (uint)(Data.Length / 3);

        void SetBounds(float[] vectors) {
            // TODO: improve logic and performance
            List<float> vx = new List<float>();
            List<float> vy = new List<float>();
            List<float> vz = new List<float>();
            for (int i = 0; i < vectors.Length; i += 3) {
                vx.Add(vectors[i]);
                vy.Add(vectors[i + 1]);
                vz.Add(vectors[i + 2]);
            }

            _min = new float[] { vx.Min(), vy.Min(), vz.Min() };
            _max = new float[] { vx.Max(), vy.Max(), vz.Max() };
        }
    }
}