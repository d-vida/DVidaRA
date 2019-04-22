using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Steps : MonoBehaviour
{

    Fade fade;
    public GameObject SplashPage;
    public GameObject inf1, inf2;
    public RectTransform mainMenu, step2, step3, step4, step5;
    public GameObject Right, Right1, Right2, Left, Left1, Left2;

    public GameObject background;



    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<Fade>();
        StartCoroutine(Play());
        fade.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Play()
    {
        fade.BeginFade(+1);
        yield return new WaitForSeconds(2);
        background.SetActive(false);
        fade.BeginFade(-1);
    }

    //Dotween para dar swipe nos objetos na ida
    public void ToStep1()
    {
        Debug.Log("passou");
        mainMenu.DOAnchorPos(new Vector2(-1050, 43), 0.25f);
        step2.DOAnchorPos(new Vector2(0, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(false);
        Left2.SetActive(true);
        Right.SetActive(false);
        Right1.SetActive(true);
        Right2.SetActive(false);

    }
    public void ToStep2()
    {
        step2.DOAnchorPos(new Vector2(-1050, 43), 0.25f);
        step3.DOAnchorPos(new Vector2(0, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(true);
        Left2.SetActive(false);
        Right.SetActive(false);
        Right1.SetActive(false);
        Right2.SetActive(true);
    }
    public void ToStep3()
    {
        step3.DOAnchorPos(new Vector2(-1050, 43), 0.25f);
        step4.DOAnchorPos(new Vector2(0, 43), 0.25f);
        Left.SetActive(true);
        Left1.SetActive(false);
        Left2.SetActive(false);
        Right.SetActive(false);
        Right1.SetActive(false);
        Right2.SetActive(false);


    }public void ToStep4()
    {
        inf1.SetActive(false);
        inf2.SetActive(false);
        step4.DOAnchorPos(new Vector2(-1050, 43), 0.25f);
        step5.DOAnchorPos(new Vector2(0, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(false);
        Left2.SetActive(false);
        Right.SetActive(false);
        Right1.SetActive(false);
        Right2.SetActive(false);
    }
    //Dotween para dar swipe nos objetos na volta
    public void BackStep1()
    {
        Debug.Log("passou");
        mainMenu.DOAnchorPos(new Vector2(0, 43), 0.25f);
        step2.DOAnchorPos(new Vector2(1050, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(false);
        Left2.SetActive(false);
        Right.SetActive(true);
        Right1.SetActive(false);
        Right2.SetActive(false);

    }
    public void BackStep2()
    {
        step2.DOAnchorPos(new Vector2(0, 43), 0.25f);
        step3.DOAnchorPos(new Vector2(1050, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(false);
        Left2.SetActive(true);
        Right.SetActive(false);
        Right1.SetActive(true);
        Right2.SetActive(false);

    }
    public void BackStep3()
    {
        step3.DOAnchorPos(new Vector2(0, 43), 0.25f);
        step4.DOAnchorPos(new Vector2(1050, 43), 0.25f);
        Left.SetActive(false);
        Left1.SetActive(true);
        Left2.SetActive(false);
        Right.SetActive(false);
        Right1.SetActive(false);
        Right2.SetActive(true);

    }
}
