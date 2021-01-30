﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Bonfire : MonoBehaviour
{
    [SerializeField] int requiredSouls;
    [SerializeField] GameObject bonfire;
    [SerializeField] Stack<GameObject> bonfireSouls;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TorchController torch;
    [SerializeField] GameObject notification;
    [SerializeField] LeanTweenType easeType;
    [SerializeField] TextMeshProUGUI notifText;
    [SerializeField] CanvasGroup mouseGroup;

    private int currentSouls;
    private bool atBonfire;
    private bool activated;

    private void Awake()
    {
        bonfireSouls = new Stack<GameObject>();
        atBonfire = false;
        notifText.text = "x" + requiredSouls.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            atBonfire = true;
            LeanTween.alphaCanvas(mouseGroup, 1, 1).setEase(easeType);
            if (!activated)
                LeanTween.scale(notification, new Vector3(0.1f, 0.1f, 0.1f), 0.75f).setEase(easeType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            atBonfire = false;
            LeanTween.alphaCanvas(mouseGroup, 0, 1).setEase(easeType);
            if (!activated)
                LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);
        }
    }

    private void checkSouls()
    {
        if (requiredSouls != 0)
            notifText.text = "x" + (requiredSouls - currentSouls).ToString();
        else
            LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);
        if (currentSouls == requiredSouls)
            torch.lightUp();
        else if (currentSouls < requiredSouls)
            torch.putOut();
    }

    public void OnDeposit(InputAction.CallbackContext context) 
    {
        if (playerStats.soulsFollowing() > 0 && atBonfire && context.performed) {
            bonfireSouls.Push(playerStats.removeSoul());
            currentSouls++;
            checkSouls();
        }
    }

    public void OnWithdraw(InputAction.CallbackContext context) {
        if (currentSouls > 0 && atBonfire && context.performed)
        {
            playerStats.addSoul(bonfireSouls.Pop());
            currentSouls--;
            checkSouls();
        }
    }
}
