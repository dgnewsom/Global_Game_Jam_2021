using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public float brightness;

    private int currentSouls;
    private Light torchLight;
    private Collider detectionCollider;
    [SerializeField] Bonfire bonfire;

    private void Awake()
    {
        detectionCollider = GetComponent<Collider>();
        torchLight = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && bonfire.checkSouls ()) // can be exchanged for the layer system
        {
            killEnemy(other.gameObject);
        }
    }

    public void killEnemy(GameObject enemy)
    {
        if (enemy.TryGetComponent(out EnemyAgent e)){
            e.Death();
        }
        else
        {
            Destroy(e);
        }
    }

    public void lightUp()
    {
        detectionCollider.enabled = true;
        torchLight.intensity = brightness;
    }

    public void putOut()
    {
        detectionCollider.enabled = false;
        torchLight.intensity = 0;
    }

}
