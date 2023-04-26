using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Entering Shop");

            UIManager.Instance.ShopOpen();
        }
    }
}
