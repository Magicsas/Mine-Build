using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineItemsController : MonoBehaviour
{
    AssembleFromComponents _assembleFromComponents;

    public MineItems MineItems;
    public int MaxItemsToSpawn = 10;

    private int _itemsSpawned = 0;

    private void Start()
    {
        _assembleFromComponents = GetComponent<AssembleFromComponents>();
        MineItems.SetCanSpawn(true);
    }
    private void Update()
    {
        if (_itemsSpawned >= MaxItemsToSpawn)
        {
            MineItems.SetCanSpawn(false);
        }

        if (_assembleFromComponents.ComponentTwo != null)
        {
            if (_assembleFromComponents.ComponentOne.ObjectInCount != 0 && _assembleFromComponents.ComponentTwo.ObjectInCount != 0)
            {
                MineItems.SetCanSpawn(true);
            }
        }
        else
        {
            if (_assembleFromComponents.ComponentOne.ObjectInCount != 0)
            {
                MineItems.SetCanSpawn(true);
            }
        }
    }
    public void ItemSpawned()
    {
        _itemsSpawned++;

        if (_assembleFromComponents.ComponentTwo != null)
        {
            _assembleFromComponents.ComponentOne.ObjectInCount--;
            _assembleFromComponents.ComponentTwo.ObjectInCount--;
        }
        else if (_assembleFromComponents.ComponentTwo == null)
        {
            _assembleFromComponents.ComponentOne.ObjectInCount--;
        }
    }
}
