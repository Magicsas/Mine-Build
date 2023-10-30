using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineItemsController : MonoBehaviour
{
    CookFood cookFood;

    public MineItems mineItems;
    public int maxItemsToSpawn = 10;

    private int itemsSpawned = 0;

    private void Start()
    {
        cookFood = GetComponent<CookFood>();
        mineItems.SetCanSpawn(true);
    }
    private void Update()
    {
        if (itemsSpawned >= maxItemsToSpawn)
        {
            mineItems.SetCanSpawn(false);
        }

        if (cookFood.ComponentTwo != null)
        {
            if (cookFood.ComponentOne.ObjectInCount != 0 && cookFood.ComponentTwo.ObjectInCount != 0)
            {
                mineItems.SetCanSpawn(true);
            }
        }
        else
        {
            if (cookFood.ComponentOne.ObjectInCount != 0)
            {
                mineItems.SetCanSpawn(true);
            }
        }
    }
    public void ItemSpawned()
    {
        itemsSpawned++;

        if (cookFood.ComponentTwo != null)
        {
            cookFood.ComponentOne.ObjectInCount--;
            cookFood.ComponentTwo.ObjectInCount--;
        }
        else if (cookFood.ComponentTwo == null)
        {
            cookFood.ComponentOne.ObjectInCount--;
        }
    }
}
