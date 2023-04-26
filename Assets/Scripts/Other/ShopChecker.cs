using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopChecker : MonoBehaviour
{
    [SerializeField] private bool inShopTrigger;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inShopTrigger)
            {
                UIManager.Instance.ShopOpen();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inShopTrigger = true;

            collision.gameObject.GetComponent<PlayerController>().canvasEmote.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inShopTrigger = false;

            collision.gameObject.GetComponent<PlayerController>().canvasEmote.SetActive(false);
        }
    }
}
