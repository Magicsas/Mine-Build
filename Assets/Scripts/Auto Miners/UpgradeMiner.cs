using UnityEngine;
using UnityEngine.UI;

public class UpgradeMiner : MonoBehaviour
{
    public MineItems Miner;
    public BuyConstruction BuyConstruction;
    public int Price;

    int _currentMoney;

    Text _minerName;
    public Text PriceText;

    private void Awake()
    {
        _minerName = GetComponentInChildren<Text>();
        Miner = BuyConstruction.ConstructionPrefab.GetComponentInChildren<MineItems>();
        _minerName.text = BuyConstruction.CunstructionIndex;

        PriceText.text = Price.ToString();
    }

    public void Upgrade()
    {
        //PlayerPrefs в котором лежит общее количество денег
        _currentMoney = PlayerPrefs.GetInt("MoneyCount");

        if (_currentMoney >= Price && _currentMoney - Price >= 0)
        {
            Miner.spawnInterval -= Miner.spawnInterval / 2;

            PlayerPrefs.SetInt("MoneyCount", _currentMoney -= Price);

            Price *= 3;
        }
        else
        {
            Debug.Log("Не хватает на улучшение");
        }

        PriceText.text = Price.ToString();
    }
}
