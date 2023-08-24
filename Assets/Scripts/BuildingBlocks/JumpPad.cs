using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpStrength;
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody _rigid = collision.gameObject.transform.GetComponent<Rigidbody>();
        _rigid.velocity = Vector3.left / 2;
        _rigid.velocity = Vector3.right / 2;
        _rigid.velocity = Vector3.forward / 2;
        _rigid.velocity = Vector3.back / 2;
        _rigid.velocity = Vector3.up * jumpStrength; //TODO rebalance it a bit
    }
}