using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public int requiredSouls;
    public float brightness;

    private int currentSouls;
    private Light torchLight;
    private Collider detectionCollider;

    private void Awake()
    {
        detectionCollider = GetComponent<Collider>();
        torchLight = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy") // can be exchanged for the layer system
        {
            Destroy(other.gameObject);
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
