using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColissionEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Bullet")
        {
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
