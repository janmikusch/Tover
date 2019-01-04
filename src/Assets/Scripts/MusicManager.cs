using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    AudioSource source;

	// Use this for initialization
	void Start ()
    {
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            GameObject.Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        source = this.gameObject.GetComponent<AudioSource>();
	}

    public void newClip(AudioClip clip)
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
