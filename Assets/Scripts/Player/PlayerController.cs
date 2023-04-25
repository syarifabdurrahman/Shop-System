using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayerInput
{
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    private Rigidbody2D r2bd;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [HideInInspector] public Vector2 movementDirection;

    private void Awake()
    {
        r2bd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        r2bd.velocity = speed * Time.deltaTime * movementDirection.normalized;
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    public void MovePlayer(Vector2 movementInput)
    {
        movementDirection = movementInput;

        // Check animation here
    }

    public void StopImmedietelyy()
    {
        r2bd.velocity = Vector2.zero;
    }


}
