using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private CanvasGroup fade;
    [SerializeField] LeanTweenType easeType;

    private void Awake()
    {
        fade = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        LeanTween.alphaCanvas(fade, 0, 1).setEase(easeType);
    }

    public void fadeOut()
    {
        LeanTween.alphaCanvas(fade, 1, 1).setEase(easeType);
    }
    public void fadeIn()
    {
        LeanTween.alphaCanvas(fade, 0, 1).setEase(easeType);
    }
}
