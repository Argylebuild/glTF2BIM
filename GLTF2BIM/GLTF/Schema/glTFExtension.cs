using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GLTF2BIM.GLTF.Schema {
    [Serializable]
    public abstract class glTFExtension {
        public abstract string Name { get; }

        // TODO: generate hash
        public override int GetHashCode() {
            return Name.GetHashCode();
        }
    }
}
