using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour {
    public int Life = 10;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bluebomb = createBomb();

            Collider rb = bluebomb.GetComponent<Collider>();
            rb.isTrigger = true;
            bluebomb.GetComponent<Rigidbody>().useGravity = false;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&gameObject.transform.position.x<9)
        {
            
            transform.position = new Vector3(gameObject.transform.position.x + 1, 0, gameObject.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.transform.position.x > 0)
        {

            transform.position = new Vector3(gameObject.transform.position.x - 1, 0, gameObject.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.z > -1)
        {

            transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z - 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.z < 8)
        {

            transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z + 1);
        }

    }
    private GameObject createBomb()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = gameObject.transform.position;
        go.transform.localScale = new Vector3(.5f, .5f, .5f);
        go.AddComponent<Rigidbody>();
        go.name = "RedBomb";
        go.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
        return go;
    }

    private void OnGUI()
    {
        if (Life >= 0)
        {
            GUILayout.Label("\n\nCPU Life " + Life);
        }
        else
        {
            GUILayout.Label("YOU DIED");
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BlueBomb")
        {
            Destroy(other.gameObject);
            Life--;
        }
    }
}
