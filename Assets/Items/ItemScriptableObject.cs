using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]

public class ItemScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;

    public int Price;

    public Sprite Icon;

    public GameObject ItemPrefab;
}
