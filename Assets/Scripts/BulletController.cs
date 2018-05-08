using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject target;
    public float bulletSpeed;
    public float bulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            //Makes enemy lose health
            other.GetComponent<EnemyData>().LoseHealth(bulletDamage);

            Destroy(this.gameObject);
        }
    }

    void Update () {
	    this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * bulletSpeed);
    }
}
