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
    }

    public void UpdateHealthText(float value)
    {
        heathCount.text = value.ToString();
    }
}
