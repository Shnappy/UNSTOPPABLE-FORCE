using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform cameraTransform;
    public float speed = 8f;
    public float jumpStrenght = 500f;
    public float fastFallSpeed = 20f;
    public int health = 100;

    private Rigidbody _rigid;
    private bool isFalling = false;

    public GameObject blastwavePrefab; //TODO change that

    private void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody>();
        //_rigid.maxAngularVelocity = Mathf.Infinity;
    }

    void FixedUpdate()
    {
        var cameraForward = cameraTransform.forward;
        _rigid.AddForce(new Vector3(cameraForward.x, 0.0f, cameraForward.z) *
                        (speed * Input.GetAxis("Vertical")));
        var cameraRight = cameraTransform.right;
        _rigid.AddForce(new Vector3(cameraRight.x, 0.0f, cameraRight.z) *
                        (speed * Input.GetAxis("Horizontal")));
        //_rigid.AddTorque(-cameraTransform.forward * (speed * Input.GetAxis("Horizontal"))); //for circular motion
        //_rigid.AddTorque(cameraTransform.right * (speed * Input.GetAxis("Vertical"))); //for circular motion
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(new Vector3(0.0f, cameraTransform.up.y, 0.0f) * jumpStrenght);
            //_rigid.velocity = cameraTransform.up * jumpStrenght;
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

        else if (isFalling)
        {
            isFalling = false;
        }
    }
    
}