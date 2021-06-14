using GLTF2BIM.GLTF.Package.BaseTypes;

namespace GLTF2BIM.GLTF.Package {
    public class GLTFPackageJsonItem : GLTFPackageItem {
        public GLTFPackageJsonItem(string uri, string jsonData) {
            Uri = uri;
            Data = jsonData;
        }

        public override string Uri { get; }
        public string Data { get; }
    }
}
