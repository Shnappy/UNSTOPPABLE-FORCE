using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform cameraTransform;
    public float speed = 5f;
    public float jumpStrenght = 10f;
    public float fastFallSpeed = 20f;

    private Rigidbody _rigid;
    private bool isFalling = false;

    public GameObject blastwavePrefab; //TODO change that

    private void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody>();
        _rigid.maxAngularVelocity = Mathf.Infinity;
    }

    void Update()
    {
        _rigid.AddTorque(-cameraTransform.forward * (speed * Input.GetAxis("Horizontal")));
        _rigid.AddTorque(cameraTransform.right * (speed * Input.GetAxis("Vertical")));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = cameraTransform.up * jumpStrenght;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _rigid.velocity = -cameraTransform.up * fastFallSpeed;
            isFalling = true;
        }

        if (Input.GetKey("left alt"))
        {
            _rigid.velocity = Vector3.zero;
            _rigid.angularVelocity = Vector3.zero;
        }
    }
    //Collisions Handling, need refactoring???
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.impulse.magnitude);
        if (collision.gameObject.tag == "Surface" && isFalling)
        {
            GameObject blastwave = Instantiate(blastwavePrefab, _rigid.transform.position,  Quaternion.identity);
            BlastWave.handleBlastwave(blastwave, 50);
            isFalling = false;
        }
        
        else if (collision.gameObject.tag == "JumpPad")
        {
            _rigid.velocity = Vector3.left / 2;
            _rigid.velocity = Vector3.right / 2;
            _rigid.velocity = Vector3.forward / 2;
            _rigid.velocity = Vector3.back / 2;
            _rigid.velocity = cameraTransform.up * fastFallSpeed; //TODO rebalance it a bit
        }
        
        else if (isFalling)
        {
            isFalling = false;
        }
    }
    
}