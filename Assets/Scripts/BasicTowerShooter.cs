using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicTowerShooter : MonoBehaviour {

    GameObject bulletPrefab;
    public Transform bulletSpawnPos;
    public float timeBetweenBullets;
    float timeSinceLastBullet;

    public GameObject target;
    bool checkingObjectsInside;

    public float BulletSpeed;
    public Text debugText;
    bool hasTarget;


    void Start () {
        bulletPrefab = Resources.Load("Bullet") as GameObject;
        timeSinceLastBullet = 0.0f;
        checkingObjectsInside = false;
        hasTarget = false;
    }
	
	void Update () {
        timeSinceLastBullet += Time.deltaTime;
        if(timeSinceLastBullet > timeBetweenBullets && target != null)
        {
            ShootBullet();
            timeSinceLastBullet = 0.0f;
        }

        if(hasTarget && target == null)
        {
            hasTarget = false;
            checkingObjectsInside = true;
        }
    }

    void ShootBullet()
    {
        GameObject myBullet = Instantiate(bulletPrefab) as GameObject;
        myBullet.transform.position = bulletSpawnPos.position;
        myBullet.transform.parent = this.transform;
        myBullet.GetComponent<BulletController>().target = target;
        myBullet.GetComponent<BulletController>().bulletSpeed = BulletSpeed;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        
        //Debug.Log(other.name);
        if(target != null && other.gameObject.Equals(target))
        {
            target = null;
            checkingObjectsInside = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>().text = other.name;
        
        //debugText.text = other.name + " TAG " + other.tag;
        if (other.gameObject.tag.Equals("Enemy") && target == null)
        {
            //Destroy(other.gameObject);
            target = other.gameObject;
            hasTarget = true;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (checkingObjectsInside)
        {
            target = other.gameObject;
            hasTarget = true;
            checkingObjectsInside = false;
        }
    }
}
