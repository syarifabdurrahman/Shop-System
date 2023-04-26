using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D r2bd;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [HideInInspector] public Vector2 movementDirection;
    private Animator animator;
    public bool canMove = true;

    [Header("Interact Settings")]
    [SerializeField] float sizeOfInteractablearea = 1.5f;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        instance = this;

        r2bd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            r2bd.velocity = speed * Time.deltaTime * movementDirection.normalized;
        }
        else
        {
            StopImmedietelyy();
        }
    }

    public void MovePlayer(Vector2 movementInput)
    {
        movementDirection = movementInput;

        // Check animation here
        UpdateAnimationAndMove();
    }

    public void PickupThing()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, sizeOfInteractablearea, layerMask);

        foreach (Collider2D collider in colliders)
        {
            // Check if the collider has a pickup component
            PickupItem pickupable = collider.GetComponent<PickupItem>();
            if (pickupable != null)
            {
                // Perform the pickup operation
                pickupable.PickUp();
            }
        }
    }

    private void UpdateAnimationAndMove()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("moveX", movementDirection.x);
            animator.SetFloat("moveY", movementDirection.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    public void StopImmedietelyy()
    {
        r2bd.velocity = Vector2.zero;
        animator.SetBool("moving", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sizeOfInteractablearea);
    }

}
