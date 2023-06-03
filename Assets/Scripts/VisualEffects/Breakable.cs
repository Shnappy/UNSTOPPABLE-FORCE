using UnityEngine;

public class Breakable : MonoBehaviour
{
    //TODO read on [SerializeField]

    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collsionMultiplier = 100;
    [SerializeField] private bool _broken;
    
    public void breakWithPhysics(Collision collision)
    {
        if (_broken) return;
        if (!(collision.relativeVelocity.magnitude >= _breakForce)) return;
        
        _broken = true;
        breakObject(collision);
    }
    
    public void breakObject(Collision collision)
    {
        var replacement = Instantiate(_replacement, transform.position, transform.rotation);

        var rbs = replacement.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collsionMultiplier,
                collision.contacts[0].point, 2);
        }

        Destroy(gameObject);
    }
}