using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUpgradeUI : MonoBehaviour
{
    [SerializeField] GridLayoutGroup upgradeGrid;
    [SerializeField] GameObject upgradeCell;

    [SerializeField] List<GameObject> avaliableUpgrades;
    [SerializeField] TextMeshProUGUI heathStat;
    [SerializeField] TextMeshProUGUI manaStat;
    [SerializeField] TextMeshProUGUI manaMultiplierStat;

    private void Awake()
    {
        avaliableUpgrades = new List<GameObject>();

        AddUpgrade();
        AddUpgrade();
        AddUpgrade();

        SetHealthStat();
        SetManaStat();
        SetManaMultiplierStat();

        CharacterStats.onHealthChange += SetHealthStat;
        CharacterStats.onManaChange += SetManaStat;
    }

    public void SetHealthStat()
    {
        var text = "Health: " + CharacterStats.Health.ToString() + "/" + CharacterStats.MaxHealth.ToString();
        heathStat.text = text;
    }

    public void SetManaStat()
    {
        var text = "Mana: " + CharacterStats.Mana.ToString();
        manaStat.text = text;
    }

    public void SetManaMultiplierStat()
    {
        var text = "Mana Mutiplier: " + CharacterStats.ManaMultiplier.ToString();
        manaMultiplierStat.text = text;
    }

    public void AddUpgrade()
    {
        var cell = Instantiate(upgradeCell, upgradeGrid.transform);
        avaliableUpgrades.Add(cell);
    }

}
