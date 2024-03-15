using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;
    public Image fill;

    private void Awake()
    {
        instance = this;
    }

    public void SetEnergy(float CE, float ME)
    {
        fill.transform.localScale = new Vector3(CE / ME, 1f, 1f);
    }
}
