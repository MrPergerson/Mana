using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI costText;

    [SerializeField] Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void PurchaseUpgrade()
    {

    }
}
