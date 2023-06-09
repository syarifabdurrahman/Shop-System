using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour, IPlayerInput
{
    [field: SerializeField]
    public UnityEvent onPickupKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent onInventoryKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    private void Update()
    {
        GetPickupInput();
        GetMovementInput();
        GetInventoryInput();
    }

    private void GetInventoryInput()
    {
        if (Input.GetAxisRaw("Inventory") > 0)
        {
            onInventoryKeyPressed?.Invoke();
        }
    }

    private void GetPickupInput()
    {
        if (Input.GetAxisRaw("Pickup") > 0)
        {
            onPickupKeyPressed?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
