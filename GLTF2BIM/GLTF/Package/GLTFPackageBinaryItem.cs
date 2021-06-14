using GLTF2BIM.GLTF.Package.BaseTypes;

namespace GLTF2BIM.GLTF.Package {
    public class GLTFPackageBinaryItem : GLTFPackageItem {
        public GLTFPackageBinaryItem(string uri, byte[] binaryData) {
            Uri = uri;
            Data = binaryData;
        }

        public override string Uri { get; }
        public byte[] Data { get; }
    }
}
