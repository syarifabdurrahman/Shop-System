using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerPreview : MonoBehaviour
{
    private Animator animator;
    private Vector2[] positions;
    private int currentPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CreatePositions();
    }

    private void OnEnable()
    {
        currentPosition = 0;
        CreatePositions();
    }

    private void CreatePositions()
    {
        positions = new Vector2[4];
        positions[0] = new Vector2(0, -1);
        positions[1] = new Vector2(-1, 0);
        positions[2] = new Vector2(0, 1);
        positions[3] = new Vector2(1, 0);
    }

    public void RotateLeft()
    {
        if (currentPosition < positions.Length - 1)
        {
            currentPosition++;
        }
        else
        {
            currentPosition = 0;
        }

        UpdatePosition();
    }

    public void RotateRight()
    {
        if (currentPosition > 0)
        {
            currentPosition--;
        }
        else
        {
            currentPosition = positions.Length - 1;
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        animator.SetFloat("moveX", positions[currentPosition].x);
        animator.SetFloat("moveY", positions[currentPosition].y);
    }
}
