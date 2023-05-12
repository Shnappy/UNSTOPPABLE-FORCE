using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   private Vector3 offset;

   private void Start()
   {
       offset = transform.position - target.position;
   }

   private void Update()
   {
       var targetPosition = target.position;
       transform.position = new Vector3(
           targetPosition.x + offset.x,
           targetPosition.y + offset.y,
           targetPosition.z + offset.z);
   }
}