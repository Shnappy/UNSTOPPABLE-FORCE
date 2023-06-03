using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollByAxisX = 0.5f;
    public float scrollByAxisY = 0.5f;
    
    void Update()
    {
        float OffsetX = Time.time * scrollByAxisX;
        float OffsetY = Time.time * scrollByAxisY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY); //TODO deal with an expensive method
    }
}
