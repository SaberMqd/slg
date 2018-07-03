using System;
using Unity.Entities;
using UnityEngine;

namespace slg.map {

    [Serializable]
    public struct FileCreateMap : ISharedComponentData
    {
        public string path;
        public bool use_defalt_path;
    }

    public class FileCreateMapComponent : SharedComponentDataWrapper<FileCreateMap> { }
}