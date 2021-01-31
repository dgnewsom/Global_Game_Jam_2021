using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EndLevel : MonoBehaviour
{
    [SerializeField]DoorOpen trigger;
  

    private void OnTriggerEnter(Collider other)
    {
        if (trigger.LevelComplete() && other.gameObject.tag.Equals("Player")) {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(currentSceneIndex++);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }

}
