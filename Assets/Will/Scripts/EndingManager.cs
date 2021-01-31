using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeOut;
    [SerializeField] CanvasGroup fadeIn;
    [SerializeField] CanvasGroup text;
    [SerializeField] LeanTweenType easeType;
    [SerializeField] AudioSource audioD;

    private void Awake()
    {
        StartCoroutine(FadeOut());
        LeanTween.alphaCanvas(fadeIn, 0, 1).setEase(easeType);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(40.75f);
        LeanTween.alphaCanvas(fadeOut, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(2);
        StartCoroutine(fadeOutMusic());
        LeanTween.alphaCanvas(fadeIn, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(text, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }

    IEnumerator fadeOutMusic()
    {
        while (audioD.volume > 0)
        {
            audioD.volume -= Time.deltaTime * 1.2f;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}
