using UnityEngine;

public class DoorOpen : MonoBehaviour
{
 [SerializeField]   GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        door.transform.position += new Vector3(0,-10,0);
        print("door");
    }
}
