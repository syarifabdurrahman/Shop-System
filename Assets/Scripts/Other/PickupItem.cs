using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : PickableItem
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] bool isPickingUp = false;

    public ItemSO item;
    public int count = 1;

    private void Start()
    {
        player = PlayerController.instance.gameObject.transform;
    }

    private void Update()
    {
        if(isPickingUp)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > pickupDistance)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (distance <= 0.1f)
            {
                if (InventoryPanel.instance.itemContainer != null)
                {
                    InventoryPanel.instance.itemContainer.Add(item, count);
                }

                Destroy(gameObject);
            }
        }
    }

    public override void PickUp()
    {
        isPickingUp = true;
    }
}
