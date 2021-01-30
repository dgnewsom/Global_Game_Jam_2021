using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EndLevel : MonoBehaviour
{
    [SerializeField]DoorOpen trigger;
  

    private void OnTriggerEnter(Collider other)
    {
        if (trigger.LevelComplete() && other.gameObject.tag.Equals("Player")) {
            print("Done");
        }
    }

}
