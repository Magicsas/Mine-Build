using UnityEngine;
using UnityEngine.UI;

public class UpgradeMiner : MonoBehaviour
{
    MineItems _miner;
    public BuyConstruction buyConstruction;
    public int Price;

    int _currentMoney;

    Text _minerName;
    public Text _priceText;

    private void Awake()
    {
        _minerName = GetComponentInChildren<Text>();
        _miner = buyConstruction.ConstructionPrefab.GetComponentInChildren<MineItems>();
        _minerName.text = buyConstruction.CunstructionIndex;

        _priceText.text = Price.ToString();
    }

    public void Upgrade()
    {
        _currentMoney = PlayerPrefs.GetInt("MoneyCount");

        if (_currentMoney >= Price && _currentMoney - Price >= 0)
        {
            _miner.spawnInterval -= _miner.spawnInterval / 2;

            PlayerPrefs.SetInt("MoneyCount", _currentMoney -= Price);

            Price *= 3;
        }
        else
        {
            Debug.Log("Не хватает на улучшение");
        }

        _priceText.text = Price.ToString();
    }
}
