using UnityEngine;
using VitalRouter;

namespace SuikaLike.GameFeatures;

public class PointerCommand : ICommand
{
    public long Frame { get; init; }
    public Vector2 Position { get; init; }
}

public class PointerMoveCommand : PointerCommand { }
public class PointerDownCommand : PointerCommand { }
public class PointerUpCommand : PointerCommand { }
