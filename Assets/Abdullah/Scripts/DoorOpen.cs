using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpened;
    [SerializeField] float doorHeight;
    PlayerStats playerStats;
   [SerializeField] int triggerRequirement;

    private void Start()
    {
        doorOpened = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpened) {
            if (playerStats.soulsFollowing() >= triggerRequirement) {
                door.transform.position += new Vector3(0, -doorHeight, 0);
                doorOpened = true; }
                }
        else 
        {
            if (playerStats.soulsFollowing() >= triggerRequirement)
            {
                door.transform.position += new Vector3(0, doorHeight, 0);
                doorOpened = false;
            }
        }
    }
}
