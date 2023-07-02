using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonyUi : MonoBehaviour
{
	public Text monyText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	monyText.text = PlayerSata.mony + " $" ;
    }
}
