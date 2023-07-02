using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	private TurretBluePrint turretToBuild;
	public GameObject StandardTurretPrefab;
	public GameObject MissilePrefab;
	//private ParticleSystem createEffect;
	
	public static BuildManager instance;
	
	
	void Awake()
	{
		if(instance != null) // has been alrready created befor
			return;
		instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {
    	//turretToBuild = StandardTurretPrefab;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    public GameObject GetTurretToBuild()
    {
    	return turretToBuild;
    }
    */
   
public bool CanBuild { get { return turretToBuild != null; } }
public bool HasMoney { get { return PlayerSata.mony >= turretToBuild.cost; } }


    public void SelectTurretToBuild(TurretBluePrint turret)
    {
    	turretToBuild = turret;
    	
    }
    
    
    public void BuildTurretOn(Node node)
    {
		if(PlayerSata.mony < turretToBuild.cost)
		{
			Debug.Log("Not enough money to build that!" + PlayerSata.mony);
			return;
		}

		PlayerSata.mony -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPos(), Quaternion.identity);
		turretToBuild.prefab.GetComponentInChildren<ParticleSystem>().Play();
		node.turret = turret;

		Debug.Log("Turret build! Money left: " + PlayerSata.mony);
    }
}
