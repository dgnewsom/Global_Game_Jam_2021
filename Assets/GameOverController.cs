using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeGroup;
    [SerializeField] CanvasGroup title;
    [SerializeField] CanvasGroup retry;
    [SerializeField] CanvasGroup menu;
    [SerializeField] LeanTweenType easeType;

    private void Awake()
    {
        StartCoroutine(GO());
    }

    IEnumerator GO()
    {
        LeanTween.alphaCanvas(fadeGroup, 1, 2).setEase(easeType);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(title, 1, 2).setEase(easeType);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(retry, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(menu, 1, 1).setEase(easeType);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void retryScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
