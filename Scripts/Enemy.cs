using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 5f;
	private Transform target;
	private int pointIndex = 0;
	public int health = 100;
	public int value = 50;

    void Start()
    {
    	target = WayPoints.points[0];
    }


    void Update()
    {
    	Vector3 direction = target.position - transform.position;
    	
    	transform.Translate(direction.normalized * speed * Time.deltaTime , Space.World);
    	
    	

    	if(Vector3.Distance(transform.position , target.position) <= 0.4f)
    	{
    		GoNextWayPint();
    	}
    }
    
    
    
    void GoNextWayPint()
    {
    	if(pointIndex >= WayPoints.points.Length -1)
    	{
    		EndPath();
    		return;
    	}
    	
    	
    	pointIndex++;
    	target = WayPoints.points[pointIndex];
    }
    
    void EndPath()
    {
    	PlayerSata.Lives--;
    	Destroy(gameObject);
    }
    
    public void TakeDamage(int amount)
    {
    	health -= amount;
    	if(health <= 0 ) 
    		Die();
    }
    
    void Die()
    {
    	PlayerSata.mony += value;
    	Debug.Log("+ 50 ");
    	Destroy(gameObject);
    }
}
    
