using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float panSpeed = 30f;
	public float panborder = 10f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panborder)
    	{
    		transform.Translate(Vector3.forward * panSpeed * Time.deltaTime , Space.World);
    	}
    	
    	if(Input.GetKey("s") || Input.mousePosition.y >= panborder)
    	{
    		transform.Translate(Vector3.back * panSpeed * Time.deltaTime , Space.World);
    	}
    	
    	if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panborder)
    	{
    		transform.Translate(Vector3.right * panSpeed * Time.deltaTime , Space.World);
    	}
    	
    	if(Input.GetKey("a") || Input.mousePosition.x >=panborder)
    	{
    		transform.Translate(Vector3.left * panSpeed * Time.deltaTime , Space.World);
    	}
    	
    	
    	// zooming - 27 Azar
    }
}
