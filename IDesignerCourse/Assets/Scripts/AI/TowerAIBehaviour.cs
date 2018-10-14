using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAIBehaviour : MonoBehaviour {
    //Target of the turret. By default, it will be the player
    private GameObject target;

    //Radius where the turret is able to attack the player
    public float radius = 15.0f;
    //Time between shoots
    public float FireCadency = 5.0f;
    //Current time until the next shoot
    float ReloadingTime;

    //Bullet spawn
    public GameObject shootingPoint;

    //Bullet of the turret
    public Rigidbody m_Shell;

    //Bullet velocity
    public float bulletVelocity = 2.0f;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");

        ReloadingTime = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            ReloadingTime -= Time.deltaTime;

            float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
            if (ReloadingTime <= 0.0f && distance < radius)
            {
                Fire();
                ReloadingTime = FireCadency;
            }

            Debug.Log(gameObject.transform.forward);
            gameObject.transform.LookAt(target.transform);
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Function for firing the tower's bullets
    void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_Shell, shootingPoint.transform.position, shootingPoint.transform.rotation) as Rigidbody;

        Vector3 direction = target.transform.position - gameObject.transform.position;

        shellInstance.velocity = direction * bulletVelocity;
    }
}
