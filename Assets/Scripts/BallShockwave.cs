using UnityEngine;

public class BallShockwave : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "cube")
        {
            Debug.Log("collision");   
        }
    }
}
