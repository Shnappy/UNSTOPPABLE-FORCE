using TMPro;
using UnityEngine;

public class StatsObserver : MonoBehaviour
{
    public GameObject player;
    public TMP_Text velocityText;
    public TextMeshPro comboText;
    private float velocity;
    private float combo;

    //TODO revise if has to be removed
    void Update()
    {
        getVelocity(); //FIXME Severe performance issues; bro do a fixed update!!!
        velocityText.text = "Speed: " + velocity.ToString("0.00");
    }
    
    private void getVelocity()
    {
        //velocity = player.GetComponent<Rigidbody>().velocity.magnitude;
    }
    
}
