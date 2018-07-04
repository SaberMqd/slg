using Unity.Entities;
using Unity.Transforms;

namespace slg.move
{
    public struct CreateMoveRangeData : IComponentData { }

    public struct DestroyMoveRangeData : IComponentData { }

    public struct MoveTo : IComponentData {
        public Position position;
    }
}