using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

using Newtonsoft.Json;

using GLTF2BIM.GLTF.Extensions.BIM.BaseTypes;

namespace GLTF2BIM.GLTF.Extensions.BIM.Schema {
    [Serializable]
    public abstract class glTFBIMNodeExtension : glTFBIMExtension {
        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        // e.g. revit::Door::MyFamily::MyFamilyType
        [JsonProperty("taxonomies", Order = 2)]
        public virtual List<string> Taxonomies { get; set; } = new List<string>();

        [JsonProperty("classes", Order = 3)]
        public virtual List<string> Classes { get; set; } = new List<string>();

        [JsonProperty("mark", Order = 4)]
        public virtual string Mark { get; set; }

        [JsonProperty("description", Order = 5)]
        public virtual string Description { get; set; }

        [JsonProperty("comment", Order = 6)]
        public virtual string Comment { get; set; }

        [JsonProperty("uri", Order = 7)]
        public virtual string Uri { get; set; }

        [JsonProperty("dataUrl", Order = 8)]
        public virtual string DataUrl { get; set; }

        [JsonProperty("imageUrl", Order = 9)]
        public virtual string ImageUrl { get; set; }

        [JsonProperty("level", Order = 11)]
        public virtual string Level { get; set; }

        [JsonProperty("bounds", Order = 12)]
        public virtual glTFBIMBounds Bounds { get; set; }

        [JsonProperty("properties", Order = 99)]
        public virtual Dictionary<string, object> Properties { get; set; }
        
        [JsonProperty("bucketId", Order = 100)]
        public virtual string Bucket { get; set; }
    }

    [Serializable]
    public class glTFBIMBounds : ISerializable {
        public glTFBIMBounds(float minx, float miny, float minz,
                             float maxx, float maxy, float maxz) {
            Min = new glTFBIMVector(minx, miny, minz);
            Max = new glTFBIMVector(maxx, maxy, maxz);
        }

        public glTFBIMBounds(glTFBIMVector min, glTFBIMVector max) {
            Min = min;
            Max = max;
        }

        public glTFBIMBounds(glTFBIMBounds bounds) {
            Min = new glTFBIMVector(bounds.Min);
            Max = new glTFBIMVector(bounds.Max);
            if (bounds.LinkHostBounds != null)
                LinkHostBounds = new glTFBIMBounds(bounds.LinkHostBounds);
        }

        public glTFBIMBounds(SerializationInfo info, StreamingContext context) {
            var min = (float[])info.GetValue("min", typeof(float[]));
            Min = new glTFBIMVector(min[0], min[1], min[2]);
            var max = (float[])info.GetValue("max", typeof(float[]));
            Max = new glTFBIMVector(max[0], max[1], max[2]);
        }

        [JsonProperty("min")]
        public glTFBIMVector Min { get; set; }

        [JsonProperty("max")]
        public glTFBIMVector Max { get; set; }

        public glTFBIMBounds LinkHostBounds { get; set; } = null;

        public void Union(glTFBIMBounds other) {
            Min.ContractTo(other.Min);
            Max.ExpandTo(other.Max);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("min", new double[] { Min.X, Min.Y, Min.Z });
            info.AddValue("max", new double[] { Max.X, Max.Y, Max.Z });
        }
    }

    [Serializable]
    public class glTFBIMVector {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public glTFBIMVector(float x, float y, float z) {
            X = x; Y = y; Z = z;
        }

        public glTFBIMVector(glTFBIMVector vector) {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public void ContractTo(glTFBIMVector other) {
            X = other.X < X ? other.X : X;
            Y = other.Y < Y ? other.Y : Y;
            Z = other.Z < Z ? other.Z : Z;
        }

        public void ExpandTo(glTFBIMVector other) {
            X = other.X > X ? other.X : X;
            Y = other.Y > Y ? other.Y : Y;
            Z = other.Z > Z ? other.Z : Z;
        }
    }
}
