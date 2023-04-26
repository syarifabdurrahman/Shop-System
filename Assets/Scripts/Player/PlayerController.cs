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

    private void Awake()
    {
        r2bd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        instance = this;
    }


    private void FixedUpdate()
    {
        r2bd.velocity = speed * Time.deltaTime * movementDirection.normalized;
    }

    public void MovePlayer(Vector2 movementInput)
    {
        movementDirection = movementInput;

        // Check animation here
        UpdateAnimationAndMove();
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
    }


}
