using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Camera zoom")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float cameraRange;
    [SerializeField] private float cameraTransitionSpeed;
    private float initialCameraSize;
    private float currentCameraSize;
    private float targetCameraSize;
    private float cameraZoomIncrement;

    [Space]
    [SerializeField] private int maxSoulsFollowing;
    
    [Space]
    [Header("Light Radius")]
    [SerializeField] private float baseLightRadius;
    [SerializeField] private float maxLightRadius;
    [SerializeField] private float lightTransitionSpeed;
    private float targetLightRadius;
    private float currentLightRadius;
    private float lightRadiusIncrement;

    private Stack<GameObject> souls;        // current following souls
    private float currentHealth;
    
    private bool isDead;

    private void Awake()
    {
        currentLightRadius = baseLightRadius;
        targetLightRadius = baseLightRadius;
        souls = new Stack<GameObject>();
        initialCameraSize = playerCamera.orthographicSize;
        currentCameraSize = playerCamera.orthographicSize;
        targetCameraSize = playerCamera.orthographicSize;
        cameraZoomIncrement = cameraRange / maxSoulsFollowing;
        lightRadiusIncrement = maxLightRadius / maxSoulsFollowing;
        isDead = false;

    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            targetLightRadius = 200f;
        }
        currentLightRadius = Mathf.Lerp(currentLightRadius, targetLightRadius, 5f * Time.deltaTime);
        currentCameraSize = Mathf.Lerp(currentCameraSize, targetCameraSize, 5f * Time.deltaTime);
        playerCamera.orthographicSize = currentCameraSize;
    }
    //Light

    public void IncreaseLightRadius()
    {
        targetLightRadius += lightRadiusIncrement;
        targetCameraSize += cameraZoomIncrement;

    }

    public void DecreaseLightRadius()
    {
        targetLightRadius -= lightRadiusIncrement;
        targetCameraSize -= cameraZoomIncrement;
    }
    
    public void Die()
    {
        
        isDead = true;
        //add gameover screen
    }

    // Souls

    public int SoulsFollowing()
    {
        return souls.Count;
    }

    public void AddSoul(GameObject soul)
    {
        IncreaseLightRadius();
        if (!souls.Contains(soul)) {
            souls.Push(soul); }
    }

    public GameObject RemoveSoul()
    {
        DecreaseLightRadius();
        return souls.Pop();
    }

    public GameObject[] RemoveSouls(int amountOfSouls)
    {
        GameObject[] toReturn = souls.ToArray();
        souls.Clear();
        playerCamera.orthographicSize = initialCameraSize;
        targetLightRadius = baseLightRadius;
        return toReturn;
        
    }

    public void AddSouls(GameObject[] soulsToAdd)
    {
        for (int i = 0; i <= soulsToAdd.Length; i++)
        {
            AddSoul(soulsToAdd[i]);
        }
    }

    public float GetLightRadius()
    {
        return currentLightRadius;
    }
}
