using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject portalTo;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = portalTo.transform.position;
    }
}