using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.EventSystem;

public class Node : MonoBehaviour
{
	BuildManager buildManager;
	
	public Color hoverColor;
	public Color MonyLossColor;
	
	private Color startColor;
	
	private MeshRenderer rndr;
	 
	public GameObject turret;
	
	public Vector3 posOffset;
	
	
    // Start is called before the first frame update
    void Start()
    {
    	rndr = GetComponent<MeshRenderer>();
    	startColor = rndr.material.color;
    	
    	buildManager = BuildManager.instance;
    	
    }

    // Update is called once per frame
    void Update()
    {
    	
    }
    	
    
    void OnMouseEnter()
    {
    	if (EventSystem.current.IsPointerOverGameObject())
			return;
    	
    	if(!buildManager.CanBuild)
    		return;
    	
    	if(buildManager.HasMoney)
    		rndr.material.color = hoverColor;
    	else
    		rndr.material.color = MonyLossColor;
    	
    }
    
    void OnMouseExit()
    {
    	rndr.material.color = startColor;
    	
    }
    
    void OnMouseDown() //click
    {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
    	
    	if(!buildManager.CanBuild)
    		return;
    	
    	if(turret != null){
    		Debug.Log("Error!!!");
    		return;}
    	
    	
    	buildManager.BuildTurretOn(this);
    }
    
    public Vector3 GetBuildPos()
    {
    	return (transform.position + posOffset);
    }
}
