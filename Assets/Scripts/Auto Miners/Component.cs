using UnityEngine;

public class Component : MonoBehaviour
{
    public string WhatComponentCanTake;
    public int ObjectInCount;
    public int ObjectInMax;

    //Скинуть нужные в руках компоненты для дальнейшей переработки
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<UseItem>() != null && other.GetComponent<UseItem>()._items.Count > 0 && ObjectInCount < ObjectInMax)
        {
            for (int i = 0; i < other.GetComponent<UseItem>()._items.Count; i++)
            {
                if (other.GetComponent<UseItem>()._items[i].ItemScriptableObject.Name == WhatComponentCanTake)
                {
                    ObjectInCount++;
                    Destroy(other.GetComponent<UseItem>()._items[i].gameObject);
                    other.GetComponent<UseItem>()._items.RemoveAt(i);
                }
            }
        }
    }
}
