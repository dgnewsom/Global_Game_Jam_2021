using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;                // starting health
    public float baseLightRadius;
    public int maxSoulsFollowing;

    private Stack<GameObject> souls;        // current following souls
    private float currentMaxHealth;
    private float currentHealth;
    [SerializeField] private float currentLightRadius;

    private void Awake()
    {
        currentMaxHealth = health;
        currentHealth = currentMaxHealth;
        currentLightRadius = baseLightRadius;
        souls = new Stack<GameObject>();
    }

    //Light

    public void increaseLightRadius(float radius)
    {
        currentLightRadius += radius;
    }

    public void decreaseLightRadius(float radius)
    {
        currentLightRadius -= Mathf.Clamp(radius, 0, radius);
    }

    public void setLightRadius(float radius)
    {
        currentLightRadius = radius;
    }

    // Health

    public float healthCurrent()
    {
        return currentHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            die();
    }

    public void restoreHealth(float restoredHealth)
    {
        currentHealth += restoredHealth;
        Mathf.Clamp(currentHealth, 0, currentMaxHealth);
    }

    public void restoreMaxHealth()
    {
        currentHealth = currentMaxHealth;
    }

    private void die()
    {
        Destroy(gameObject, 3); // 3 seconds to compensate for possible death animation
    }

    // Souls

    public int soulsFollowing()
    {
        return souls.Count;
    }

    public void addSoul(GameObject soul)
    {
        if (!souls.Contains(soul)) {
            souls.Push(soul); }
    }

    public GameObject removeSoul()
    {
       return souls.Pop();
    }

    public void removeSouls(int amountOfSouls)
    {
        for (int i = 0; i <= amountOfSouls; i++)
        {
            removeSoul();
        }
    }

    public void addSouls(GameObject[] soulsToAdd)
    {
        for (int i = 0; i <= soulsToAdd.Length; i++)
        {
            addSoul(soulsToAdd[i]);
        }
    }

    public float GetLightRadius()
    {
        return currentLightRadius;
    }
}
