using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] menuArt;
    public LeanTweenType easeType;
    public float defaultFallTime;
    public float fallMultiplier;

    public CanvasGroup startBtn;
    public CanvasGroup quitBtn;
    public CanvasGroup fade;

    public Sound music;
    public Sound SFX;

    private void Start()
    {
        StartCoroutine(menuAnim());
        LeanTween.alphaCanvas(fade, 0, 1).setEase(easeType);
        SFX.Play();
    }

    IEnumerator menuAnim()
    {
        float fallTime = defaultFallTime;
        foreach (GameObject art in menuArt)
        {
            LeanTween.moveY(art, 0, fallTime).setEase(easeType);
            fallTime += fallMultiplier;
        }
        yield return new WaitForSeconds(4);
        music.Play();
        yield return new WaitForSeconds(5);
        LeanTween.alphaCanvas(startBtn, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(quitBtn, 1, 1).setEase(easeType);
    }


}
