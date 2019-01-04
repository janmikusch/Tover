using UnityEngine;
using System.Collections;

public class clouds : MonoBehaviour {

    public float speed = 5;
	
    void Awake()
    {
        speed = Random.Range(0.8f, 5f);
    }

	// Update is called once per frame
	void Update ()
    {
        this.transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
	}
}
