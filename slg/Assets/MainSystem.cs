using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class MainSystem : Feature {
    public MainSystem(Contexts c)
    {
        Add(new PositionAddSystem(c));

        Add(new InputSystem(c));
    }
}
