using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform targetOrder;

    [SerializeField] private bool isYBigger;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        targetOrder = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (!isYBigger)
        {
            if (targetOrder.transform.position.y > transform.position.y)
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
            }
            else
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 10f);
            }
        }
        else
        {
            if (targetOrder.transform.position.y > transform.position.y)
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 10f);
            }
            else
            {
                spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
            }
        }
    }
}
