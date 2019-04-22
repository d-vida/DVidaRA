using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    private YieldInstruction fadeInstruction = new YieldInstruction();
    //fade
    public UnityEngine.UI.Image splashPage;
    public float fadeSpeed = 0.8f;
    int drawDepth = -1000;
    float alpha = 1.0f;
    int fadeDir = -1;
    public GameObject splash;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeCoroutines());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeCoroutines()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3);
        background.SetActive(false);
        StartCoroutine(FadeOut());

    }


    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color c = splashPage.color;
        while (elapsedTime < fadeSpeed)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeSpeed);
            splashPage.color = c;
        }
        splash.SetActive(false);
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color c = splashPage.color;
        while (elapsedTime < fadeSpeed)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeSpeed);
            splashPage.color = c;
        }
    }
}
