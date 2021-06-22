using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPos : MonoBehaviour
{
    public Transform obj;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        Vector3 newpos = new Vector3(obj.transform.position.x - transform.position.x, obj.transform.position.y - transform.position.y + 1.5f, obj.transform.position.z - transform.position.z);
        transform.Translate(newpos);
    }
}
