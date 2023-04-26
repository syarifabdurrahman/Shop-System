using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput
{
    UnityEvent onInventoryKeyPressed { get; set; }
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
}
