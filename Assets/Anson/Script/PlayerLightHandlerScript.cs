using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerLightHandlerScript : MonoBehaviour
{
    [Header("Range")]
    [SerializeField] float detectionRange;

    [Header("Material")]
    [SerializeField] List<Material> materials;
    [Header("Light")]
    [SerializeField] Light playerLight;
    [SerializeField] float intensityModifier = 0.4f;
    [SerializeField] float intensityClamp = 3f;
    [Header("Flame")]
    [SerializeField] VisualEffect flameEffect;
    [SerializeField] Transform core;
    [SerializeField] float coreMultiplier;
    float initialSize;
    [Header("LightRing")]
    [SerializeField] VisualEffect ringEffect;

    private void Awake()
    {
        initialSize = flameEffect.GetFloat("Size");
    }

    private void FixedUpdate()
    {
        UpdateRange();
    }

    public void UpdateRange(float range)
    {
        detectionRange = range;
    }

    public void UpdateRange()
    {
        playerLight.range = detectionRange*1.1f;
        playerLight.intensity = Mathf.Clamp(detectionRange * intensityModifier,0,intensityClamp);
        flameEffect.SetFloat("Size", initialSize + (detectionRange * coreMultiplier));
        ringEffect.SetFloat("SizeRange", detectionRange);
        //flameEffect.SetFloat("SizeRange", detectionRange);
    }

    public float DetectionRange { get => detectionRange; set => detectionRange = value; }
}
