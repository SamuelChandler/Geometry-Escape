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

    private void SetOpacity()
    {
        float fill_scale = fill.transform.localScale.x;
        float opacity = (fill_scale - 0.8f) / 0.2f;
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 1f - opacity);
        GetComponent<Image>().color = new Color (GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f - opacity);

    }

    public void Update()
    {
        if (fill.transform.localScale.x > 0.8f) { SetOpacity(); }
        else { 
            fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 1f);
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f); ; }

    }
}
