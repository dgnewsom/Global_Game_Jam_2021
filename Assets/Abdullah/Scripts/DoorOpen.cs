using TMPro;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpened;
    [SerializeField] float doorHeight;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] int triggerRequirement;
    [SerializeField] TextMeshProUGUI plateText;
    [SerializeField] GameObject notification;
    [SerializeField] LeanTweenType easeType;

    [SerializeField] Sound sound_Activate;

    private void Start()
    {
        doorOpened = false;
        if (playerStats == null)
        {            playerStats = FindObjectOfType<PlayerStats>();
        }

        plateText.text = playerStats.SoulsFollowing().ToString() + "/" + triggerRequirement.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LeanTween.scale(notification, new Vector3(0.1f, 0.1f, 0.1f), 0.75f).setEase(easeType);
        plateText.text = playerStats.SoulsFollowing().ToString() + "/" + triggerRequirement.ToString();
        if (other.gameObject.tag.Equals("Player"))
            if (playerStats.SoulsFollowing() >= triggerRequirement)
            {
                {

                    sound_Activate.PlayF();
                    if (!doorOpened)
                    {

                        {
                            door.transform.position += new Vector3(0, -doorHeight, 0);
                            doorOpened = true;
                        }
                    }
                    else
                    {
                        /*
                        LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);

                        plateText.text = "x" + triggerRequirement.ToString();
            */
                        if (playerStats.SoulsFollowing() >= triggerRequirement)
                        {
                            door.transform.position += new Vector3(0, doorHeight, 0);
                            doorOpened = false;

                        }
                    }
                }

            }
    }

    public bool LevelComplete()
    {
        return doorOpened;
    }
}
