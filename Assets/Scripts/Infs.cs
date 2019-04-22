using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infs : MonoBehaviour
{

    public Fade fade;
    public GameObject splashPage;
    public GameObject background;


    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<Fade>();
        StartCoroutine(Play());
        fade.alpha = 0;
        
    }

    IEnumerator Play()
    {
        fade.BeginFade(+1);
        yield return new WaitForSeconds(2);
        background.SetActive(false);
        fade.BeginFade(-1);
    }


}
