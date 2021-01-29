using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpened;
    [SerializeField] float doorHeight;
    private void Start()
    {
        doorOpened = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpened) {
            door.transform.position += new Vector3(0, -doorHeight, 0);
            doorOpened = true;
                }
        else 
        {
            door.transform.position += new Vector3(0, doorHeight, 0);
            doorOpened = false;
        }
    }
}
