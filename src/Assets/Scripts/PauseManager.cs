using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public bool paused;
    public Canvas menuCanvas;


    public static PauseManager instance { set; get; }

    // Use this for initialization
    void Start () {
        instance = this;
        paused = false;
	}
	
	public void PauseGame()
    {
        paused = true;
        menuCanvas.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        paused = false;
        menuCanvas.gameObject.SetActive(false);

    }
}
