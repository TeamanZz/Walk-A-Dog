using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolitionBehaivor : MonoBehaviour
{
    public int demolitionPercent;

    public void IncreaseDemolition()
    {
        DemolitionManager.Instance.IncreaseDemolitionPercent(demolitionPercent);
    }
}