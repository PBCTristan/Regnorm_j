using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHB : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public int playerindex;

    
    public void SetHealth(int _health)
    {
        slider.value = _health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        SetHealth(GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().Players[playerindex].GetChild(0).GetComponent<EnemyHealth>().currenthealth);
    }
}
