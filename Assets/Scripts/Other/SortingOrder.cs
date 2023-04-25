using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Transform target;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target.transform.position.y > transform.position.y)
        {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
        }
        else
        {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 10f);
        }

    }
}
