//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FadeObject : MonoBehaviour
//{
//    public GameObject rend;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void SetMaterialOpaque()
//    {
//        foreach(Material m in GetComponent<Renderer>().materials)
//        {
//            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
//            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
//            m.SetInt("_ZWrite", 1);
//            m.renderQueue = -1;
//        }
//    }


//    public void startFading()
//    {
//        iTween.FadeTo(rend, 1, 1);

//        Invoke("SetMaterialOpaque", 1.0f);
//    }
//}
