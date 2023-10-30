using UnityEngine;
using UnityEngine.UI;

public class BuyConstruction : MonoBehaviour
{
    public ItemScriptableObject Item;
    public GameObject ConstructionPrefab;
    public int price;
    public string CunstructionIndex;

    Text _priceText;

    public GameObject MinerUpgradePanel;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(CunstructionIndex) == 1)
        {
            //Создать конструкцию
            GameObject newConstruction = Instantiate(ConstructionPrefab, transform.position, Quaternion.identity);
            newConstruction.GetComponentInChildren<MineItems>().itemTemplate = Item;

            //Включить его улучшение в меню и уничтожить объект-создатель
            MinerUpgradePanel.SetActive(true);
            Destroy(gameObject);
        }

        _priceText = GetComponentInChildren<Text>();
        _priceText.text = price.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        int _currentMoney = PlayerPrefs.GetInt("MoneyCount");

        if (PlayerPrefs.GetInt(CunstructionIndex) == 0)
        {
            if (other.CompareTag("Player"))
            {
                if (_currentMoney >= price && _currentMoney - price >= 0)
                {
                    GameObject newConstruction = Instantiate(ConstructionPrefab, transform.position, Quaternion.identity);
                    newConstruction.GetComponentInChildren<MineItems>().itemTemplate = Item;

                    _currentMoney -= price;
                    Debug.Log(_currentMoney);

                    PlayerPrefs.SetInt("MoneyCount", _currentMoney);

                    PlayerPrefs.SetInt(CunstructionIndex, 1);
                    PlayerPrefs.Save();

                    MinerUpgradePanel.SetActive(true);

                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Не хватает денег");
                }
            }
        }
    }
}
