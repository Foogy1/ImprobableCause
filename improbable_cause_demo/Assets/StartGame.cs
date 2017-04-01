using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(() => start());
    }
	
	// Update is called once per frame
	void start()
    {
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }
}
