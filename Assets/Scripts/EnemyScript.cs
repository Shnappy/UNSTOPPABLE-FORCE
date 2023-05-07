using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float currentEnemyHealth;
    public float maxEnemyHealth = 3;

    public HealthbarScript _healthbar;


    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;

        _healthbar.updateHealthBar(maxEnemyHealth, currentEnemyHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentEnemyHealth -= 1;
        
        if(currentEnemyHealth == 0)
        {
           Destroy(gameObject);
        }
        else
        {
            _healthbar.updateHealthBar(maxEnemyHealth, currentEnemyHealth);
        }

    }

}
