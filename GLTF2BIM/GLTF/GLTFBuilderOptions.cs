using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLTF2BIM.GLTF {
    public class GLTFBuilderOptions {
        public bool UseSingleBinary { get; set; } = false;

        public int MaxBinarySize { get; set; } = int.MaxValue;
    }
}
