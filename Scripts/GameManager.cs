using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	bool gameEnd = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(gameEnd)
    		return;
    	
    	if (PlayerSata.Lives <= 0)
    		Endgame();
    }
    
    void Endgame()
    {
    	gameEnd = true;
    	Debug.Log("end game !!!");
    }
}
