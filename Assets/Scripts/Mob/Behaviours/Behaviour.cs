using UnityEngine;

public class Behaviour : MonoBehaviour
{
    //fields to be inherited by behaviours
    
    //mob fields
    public Transform player;
    public Transform weapon;
    public Transform head;
    public float chaseRange = 10f;
    public float shootingRange = 7f;
    public float evadeRange = 3f;
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;
    
    //mob shooting fields
    public GameObject bulletPrefab;
    public GameObject barrelObject;
    public float bulletSpeed = 10f;
    public float maxDistance = 100f;
    public float projectileLifetime = 3;
    public float bulletInterval = 1f;
    public float reloadTime = 3;
    public int fireRate = 3;
    
}
