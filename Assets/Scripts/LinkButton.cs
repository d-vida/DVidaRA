using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkButton : MonoBehaviour
{
   

    public void Website()
    {
        Application.OpenURL("http://dvida.digital");
    }
    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/dvida.digital/?hl=pt-br");
    }
    public void Youtube()
    {
        Application.OpenURL("");
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/dvidadigital");
    }
    public void Facebook()
    {
        Application.OpenURL("https://www.facebook.com/dvidadigital/");
    }
}
