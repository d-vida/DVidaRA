using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject burguer;
    public GameObject sushi;
    public bool burguerIsActive;

    // Start is called before the first frame update
    void Start()
    {
        burguerIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            Change();
        }

    }

    public void Change()
    {
        if (burguerIsActive == true)
        {
            burguer.SetActive(false);
            sushi.SetActive(true);
            burguerIsActive = false;
        }
        else
        {
            burguer.SetActive(true);
            sushi.SetActive(false);
            burguerIsActive = true;
        }
    }
}
