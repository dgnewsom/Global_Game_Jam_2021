using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    private AudioSource musicVol;

    private void Awake()
    {
        musicVol = music.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(menuAnim());
        LeanTween.alphaCanvas(fade, 0, 1).setEase(easeType);
        SFX.Play();
    }

    public void exitMenuAnim()
    {
        StartCoroutine(exitMenuAnimation());
        
    }

    public void fadeOutMusicBtn()
    {
        StartCoroutine(fadeOutMusic());
    }

    IEnumerator fadeOutMusic()
    {
        while (musicVol.volume > 0)
        {
            musicVol.volume -= Time.deltaTime/1.5f;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator exitMenuAnimation()
    {
        float fallTime = 3;
        foreach (GameObject art in menuArt)
        {
            LeanTween.moveY(art, 25, fallTime).setEase(easeType);
            fallTime += 0.3f;
        }
        LeanTween.alphaCanvas(startBtn, 0, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(quitBtn, 0, 1).setEase(easeType);
        yield return new WaitForSeconds(0.25f);
        LeanTween.alphaCanvas(fade, 1, 1).setEase(easeType);
        
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
        yield return new WaitForSeconds(2.75f);
        LeanTween.alphaCanvas(fade, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(fade, 0, 1).setEase(easeType);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(startBtn, 1, 1).setEase(easeType);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(quitBtn, 1, 1).setEase(easeType);
    }


}
