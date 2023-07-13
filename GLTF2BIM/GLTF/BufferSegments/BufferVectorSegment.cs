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

        void SetBounds(float[] vectors)
        {
            float minX = vectors[0];
            float minY = vectors[1];
            float minZ = vectors[2];
            float maxX = vectors[0];
            float maxY = vectors[1];
            float maxZ = vectors[2];

            for (int i = 3; i < vectors.Length; i += 3)
            {
                float x = vectors[i];
                float y = vectors[i + 1];
                float z = vectors[i + 2];
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