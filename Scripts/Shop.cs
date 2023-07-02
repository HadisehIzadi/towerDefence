using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBluePrint standardTurret;
	public TurretBluePrint missile;
	
	BuildManager buildManager;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
    	buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SelectStandardTurret()
    {
    	buildManager.SelectTurretToBuild(standardTurret) ;
    }
    
    public void SelectMissile()
    {
    	buildManager.SelectTurretToBuild(missile) ;
    }
}
