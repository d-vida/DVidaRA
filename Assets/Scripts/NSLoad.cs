using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSLoad : MonoBehaviour {

	public GameObject LoadingPanel;
	public string sceneToLoad;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		



	}

	public void Load(){
		
		LoadingPanel.SetActive (true);
		SceneManager.LoadScene (sceneToLoad);
	}

}
