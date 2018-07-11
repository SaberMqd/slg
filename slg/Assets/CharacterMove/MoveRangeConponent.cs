using Unity.Entities;
using Unity.Transforms;

namespace slg.move
{
    public struct MoveTo : IComponentData {
        public Position position;
    }
    public struct MoveDes : IComponentData
    {
    }
}