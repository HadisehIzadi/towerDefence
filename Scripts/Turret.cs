using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	
	private Transform target;
	public Transform partToRotate;
	public float range = 7f;
	public float FireRate = 1f;
	public float FireCountDown = 0f;
	
	public string enemyTag = "Enemy";
	
	public float turnSpeed = 10f;
	
	public GameObject BulletPrefab;
	public Transform FirePoint;
	
    // Start is called before the first frame update
    void Start()
    {
    	InvokeRepeating("UpdateTarget" , 0f , 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    	if(target == null)
    	{
    		return;
    	}
    	
    	
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		
		
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		
		
		if(FireCountDown <=0f)
		{
			Shoot();
			FireCountDown = 1f / FireRate;
		}
		
		FireCountDown -= Time.deltaTime;
    }
    
    void OnDrawGizmosSelected()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position , range);
    }
    
    void UpdateTarget()
    {
    	GameObject[] enemies =GameObject.FindGameObjectsWithTag(enemyTag);
    	
    	float shortestDistance = Mathf.Infinity;
    	GameObject nearestEnemy = null;
    	 
    	foreach(GameObject enemy in enemies)
    	{
    		float distanceToEnemy = Vector3.Distance(transform.position  , enemy.transform.position);
    		
    		
    		if (distanceToEnemy < shortestDistance)
    		{
    			shortestDistance = distanceToEnemy;
    			nearestEnemy = enemy;
    		}
    	}
    	
    	if (nearestEnemy != null && shortestDistance <= range)
    	{
    		target = nearestEnemy.transform;
    	}
    	else
    	{
    		target = null;
    	}
    	
    }
    
    
    void Shoot()
    {
    	GameObject bulletGO =(GameObject)Instantiate(BulletPrefab , FirePoint.position , FirePoint.rotation);
    	Bullet bullet = bulletGO.GetComponent<Bullet>();
    	
    	if(bullet != null)
    	{
    		bullet.Seek(target);
    	}
    }
}
