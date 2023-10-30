using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    UseItem useItem;
    PlayerMovement playerMovement;
    int _price = 2500;
    public Text PriceText;

    private void Awake()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        useItem = FindAnyObjectByType<UseItem>();

        PriceText.text = _price.ToString();
    }

    public void Upgrade()
    {
        int _currentMoney = PlayerPrefs.GetInt("MoneyCount");

        if (_currentMoney >= _price && _currentMoney - _price >= 0)
        {
            useItem.MaxItem *= 2;
            playerMovement.moveSpeed++;
            PriceText.text = _price.ToString();

            PlayerPrefs.SetInt("MoneyCount", _currentMoney -= _price);
            _price *= 2;
        }
        else
        {
            Debug.Log("Не хватает на улучшение");
        }
    }
}
