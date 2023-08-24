using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public Camera _cam;
    public Image _healthbarSprite;

    void Start()
    {
        _cam = Camera.main;
    }

    public void updateHealthBar(float maxEnemyHealth, float currentEnemyHealth)
    {
        _healthbarSprite.fillAmount = currentEnemyHealth / maxEnemyHealth;

    }


    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }
}
