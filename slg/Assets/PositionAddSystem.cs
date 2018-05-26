using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class PositionAddSystem : ReactiveSystem<GameEntity> {
   

    public PositionAddSystem(Contexts c):base(c.game)
    {
            
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity  e in entities)
        {
    //        Debug.LogError();
            e.ReplacePosition(Vector3.one);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position));
    }
}
