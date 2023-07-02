using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	private Transform target;
	public GameObject effect;
	
	public float speed = 70f;
	public float ExplosionRadious = 5f;
	
	
	public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(target == null)
    	{
    		Destroy(gameObject);
    		return;
    	}
    	
    	Vector3 dir = target.position - transform.position;
    	
    	float DistanceThisFrame = speed * Time.deltaTime;
    	
    	if(dir.magnitude <= DistanceThisFrame)
    	{
    		HitTarget();
    		return;
    	}
    	
    	transform.Translate(dir.normalized * DistanceThisFrame ,Space.World);
    	
    	transform.LookAt(target);
    	
    }
    
   public void Seek(Transform _target)
    {
    	target = _target;
    }
   
   
   void HitTarget()
   {
   	
   		GameObject instEffect = (GameObject)Instantiate(effect , transform.position , transform.rotation);
   		instEffect.GetComponent<ParticleSystem>().Play();
   		if(ExplosionRadious >0f)
   			Explode();
   		else
   			Damage(target);
   		
  
   		Destroy(gameObject);
   		Destroy(instEffect , 2f);

   	
   }
   
   
   void Explode()
   {
   		Collider[] colliders = Physics.OverlapSphere(transform.position , ExplosionRadious);
   		
   		foreach ( Collider collider in colliders)
   		{
   			if(collider.tag == "Enemy")
   			{
   				Damage(collider.transform);
   			}
   		}
   	
   }
   
   void Damage( Transform target)
   {
   		Enemy e = target.GetComponent<Enemy>();
   		if(e!= null)
   			e.TakeDamage(damage);
   		//Destroy(target.gameObject);
   		
   		
   }
}
