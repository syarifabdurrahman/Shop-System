using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput
{
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
}
