using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float fastFallSpeed = 20f;
    private Rigidbody _rigid;

    private void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rigid.AddForce(Vector3.left * speed);
        }
        
        if (Input.GetAxis("Vertical") > 0)
        {
            _rigid.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _rigid.AddForce(Vector3.back * speed);
        }

        if (Input.GetKey("space"))
        {
            _rigid.AddForce(Vector3.up * jumpSpeed);
        }
        else if (Input.GetKey("left ctrl"))
        {
            _rigid.AddForce(Vector3.down * fastFallSpeed);
        }
    }
    
}