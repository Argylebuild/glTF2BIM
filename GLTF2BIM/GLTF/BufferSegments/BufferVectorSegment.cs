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
            // single pass, no intermediate allocations — this runs for every
            // candidate segment including duplicates that get discarded
            float minX = float.MaxValue, minY = float.MaxValue, minZ = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue, maxZ = float.MinValue;

            for (int i = 0; i < vectors.Length; i += 3) {
                float x = vectors[i], y = vectors[i + 1], z = vectors[i + 2];
                if (x < minX) minX = x;
                if (x > maxX) maxX = x;
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
                if (z < minZ) minZ = z;
                if (z > maxZ) maxZ = z;
            }

            _min = new float[] { minX, minY, minZ };
            _max = new float[] { maxX, maxY, maxZ };
        }
    }
}