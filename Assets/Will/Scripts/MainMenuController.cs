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
    public CanvasGroup levelSelection;

    public Sound music;
    public Sound SFX;
    public Sound btn;

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

    public void loadLvl1()
    {
        StartCoroutine(loadLevel(1));
    }
    public void loadLvl2()
    {
        StartCoroutine(loadLevel(2));
    }
    public void loadLvl3()
    {
        StartCoroutine(loadLevel(3));
    }
    public void loadLvl4()
    {
        StartCoroutine(loadLevel(4));
    }
    public void loadLvl5()
    {
        StartCoroutine(loadLevel(5));
    }
    public void loadLvl6()
    {
        StartCoroutine(loadLevel(6));
    }
    public void loadLvl7()
    {
        StartCoroutine(loadLevel(7));
    }
    public void loadLvl8()
    {
        StartCoroutine(loadLevel(8));
    }
    public void loadLvl9()
    {
        StartCoroutine(loadLevel(9));
    }
    public void loadLvl10()
    {
        StartCoroutine(loadLevel(10));
    }

    private IEnumerator loadLevel(int levelIndex)
    {
        btn.Play();
        LeanTween.alphaCanvas(levelSelection, 0, 1).setEase(easeType);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelIndex);
    }

    public void exitMenuAnim()
    {
        StartCoroutine(exitMenuAnimation());
        
    }

    public void fadeOutMusicBtn()
    {
        StartCoroutine(fadeOutMusic());
        btn.Play();
    }

    IEnumerator fadeOutMusic()
    {
        while (musicVol.volume > 0)
        {
            musicVol.volume -= Time.deltaTime/1.5f;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        LeanTween.alphaCanvas(levelSelection, 1, 1.5f).setEase(easeType);
    }

    public void quitGame()
    {
        Application.Quit();
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
        levelSelection.interactable = true;
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
