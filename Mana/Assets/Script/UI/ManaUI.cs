using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ManaUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI manaCount;
    private void Awake()
    {
        manaCount = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (manaCount == null)
            Debug.LogError("heathCount not found");

        UpdateManaText();

        CharacterStats.onManaChange += UpdateManaText;
    }
    public void UpdateManaText()
    {
        var count = (float)Math.Round(CharacterStats.Mana, 2);
        manaCount.text = count.ToString();
    }

}
