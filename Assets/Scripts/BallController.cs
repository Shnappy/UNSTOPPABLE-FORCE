using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float fastFallSpeed = 20f;
    private Rigidbody _rigid;

    public float jumpStrenght;
   // public Transform playerCamera; public float mouseSensitivity;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = Vector2.up * jumpStrenght;
            // _rigid.AddForce(Vector3.up * jumpSpeed);
        }
        else if (Input.GetKey("left ctrl"))
        {
            _rigid.AddForce(Vector3.down * fastFallSpeed);
        }
         // transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);

       // transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
    }
    
}
