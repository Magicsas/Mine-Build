using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    public Transform HandTransform;

    Item _item;

    public int MaxItem;

    public List<Item> _items = new List<Item>();

    public Text _moneyCountText;

    private void Awake()
    {
        int MoneyCount = PlayerPrefs.GetInt("MoneyCount");

        _moneyCountText.text = MoneyCount.ToString();
    }

    private void FixedUpdate()
    {
        int MoneyCount = PlayerPrefs.GetInt("MoneyCount");
        _moneyCountText.text = "Money: " + MoneyCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            if(_items.Count < MaxItem)
            {
                _item = other.GetComponent<Item>();

                _items.Add(_item);

                other.gameObject.transform.SetParent(transform, true);

                other.transform.position = HandTransform.position;
            }
            else
            {
                Debug.Log("Не осталось места");
            }
        }
        if(other.CompareTag("Shop"))
        {
            SellItem();
        }
    }

    private void SellItem()
    {
        int MoneyCount = PlayerPrefs.GetInt("MoneyCount");

        for (int i = 0; i < _items.Count; i++)
        {
            MoneyCount += _items[i].ItemScriptableObject.Price;

            Destroy(_items[i].gameObject);
        }

        PlayerPrefs.SetInt("MoneyCount", MoneyCount);

        _items.Clear();
    }
}
