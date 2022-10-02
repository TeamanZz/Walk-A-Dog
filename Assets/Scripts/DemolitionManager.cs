using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DemolitionManager : MonoBehaviour
{
    public static DemolitionManager Instance;

    public Slider slider;
    public TextMeshProUGUI percentsText;
    public float percentsValue;

    private void Awake()
    {
        Instance = this;
        UpdateView();
    }

    public void IncreaseDemolitionPercent(int value)
    {
        if (percentsValue < 100)
            percentsValue += value;
        UpdateView();
    }

    private void UpdateView()
    {
        slider.DOValue(percentsValue / 100, 0.3f);
        percentsText.text = percentsValue + "%";
    }
}