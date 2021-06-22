using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthealth;
    public HealthBarPos healthBar;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            currenthealth = 100;
            slider.value = 100f;
            transform.position = GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().spawnpoints[Random.Range(0, 3)].position;
            GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().PlayerScores[GameObject.Find("GameManager").GetComponent<PlayRoundInstantiate>().playerturn] += 25;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int _damage)
    {
        Debug.Log(_damage);
        currenthealth -= _damage;
        healthBar.SetHealth(currenthealth);
    }
}
