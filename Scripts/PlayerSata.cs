using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSata : MonoBehaviour
{
	public static int mony;
	public int StartMony = 1000;
	
	public static int Lives;
	public int StartLives = 20;
	
    // Start is called before the first frame update
    void Start()
    {
    	mony = StartMony;
    	Lives = StartLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
