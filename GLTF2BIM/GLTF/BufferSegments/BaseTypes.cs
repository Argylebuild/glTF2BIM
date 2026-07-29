using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

using GLTF2BIM.GLTF.Schema;

namespace GLTF2BIM.GLTF.BufferSegments.BaseTypes {
    public abstract class BufferSegment {
        public abstract glTFAccessorType Type { get; }
        public abstract glTFAccessorComponentType DataType { get; }
        public abstract glTFBufferViewTargets Target { get; }
        public abstract uint Count { get; }
        public abstract byte[] ToByteArray();

        public abstract object[] Min { get; }
        public abstract object[] Max { get; }

        /// <summary>
        /// Content-identity key for O(1) dedup lookups: accessor type + component
        /// type + SHA256 of the raw bytes. Typed so byte-identical data can never
        /// dedup across accessor shapes (e.g. VEC2 UVs onto VEC3 positions).
        /// </summary>
        public abstract string ContentKey { get; }
    }

    abstract class BufferSegment<T> : BufferSegment {
        string _hash = null;
        public T[] Data;
        protected T[] _min;
        protected T[] _max;

        public override object[] Min {
            get {
                var min = new object[_min.Length];
                Array.Copy(_min, min, _min.Length);
                return min;
            }
        }
        public override object[] Max {
            get {
                var max = new object[_max.Length];
                Array.Copy(_max, max, _max.Length);
                return max;
            }
        }

        public override byte[] ToByteArray() {
            int dataSize = Data.Length * Marshal.SizeOf(default(T));
            var byteArray = new byte[dataSize];
            Buffer.BlockCopy(Data, 0, byteArray, 0, dataSize);
            return byteArray;
        }

        public override uint Count => (uint)Data.Length;

        public override bool Equals(object obj) {
            if (obj is BufferSegment<T> other)
                return ComputeHash() == other.ComputeHash();
            return false;
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ContentKey => $"{Type}:{DataType}:{ComputeHash()}";

        string ComputeHash() {
            if (_hash is null)
                _hash = Encoding.UTF8.GetString(
                    SHA256.Create().ComputeHash(ToByteArray())
                    );
            return _hash;
        }
    }
}