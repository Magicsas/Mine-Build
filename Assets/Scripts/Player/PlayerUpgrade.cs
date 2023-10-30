using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    public UseItem UseItem;
    public PlayerMovement PlayerMovement;
    int _price = 2500;
    public Text PriceText;

    private void Awake()
    {
        PlayerMovement = FindAnyObjectByType<PlayerMovement>();
        UseItem = FindAnyObjectByType<UseItem>();

        PriceText.text = _price.ToString();
    }

    public void Upgrade()
    {
        //PlayerPrefs в котором лежит общее количество денег
        int _currentMoney = PlayerPrefs.GetInt("MoneyCount");

        if (_currentMoney >= _price && _currentMoney - _price >= 0)
        {
            UseItem.MaxItem *= 2;
            PlayerMovement.moveSpeed++;
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
