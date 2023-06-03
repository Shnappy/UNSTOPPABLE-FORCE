using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 3;
    public GameObject _replacement;
    public HealthbarScript _healthbar;

    void Start()
    {
        currentHealth = maxHealth;

        //_healthbar.updateHealthBar(maxEnemyHealth, currentEnemyHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentHealth -= 1;
        
        if(currentHealth == 0)
        {
            Breakable breakable = GetComponent<Breakable>();
            breakable.breakObject(collision);
        }
        else
        {
            //_healthbar.updateHealthBar(maxEnemyHealth, currentEnemyHealth);
        }

    }

}
