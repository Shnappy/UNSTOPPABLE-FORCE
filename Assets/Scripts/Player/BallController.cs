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
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigid.AddForce(cameraTransform.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rigid.AddForce(-cameraTransform.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _rigid.AddForce(cameraTransform.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _rigid.AddForce(-cameraTransform.forward * speed);
        }

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

    void OnCollisionEnter(Collision collision)
    {
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