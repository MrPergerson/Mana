using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI heathCount;

    private void Awake()
    {
        heathCount = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (heathCount == null)
            Debug.LogError("heathCount not found");

        UpdateHealthText();

        CharacterStats.onHealthChange += UpdateHealthText;
    }

    public void UpdateHealthText()
    {
        heathCount.text = CharacterStats.Health.ToString();
    }
}
