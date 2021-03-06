﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProjectileManager : MonoBehaviour
{
    public GameObject normalPhaser;

    public GameObject normalMissile;

    public Vector3 scaleModifier;

    private Queue<GameObject> shotPool;

    private Queue<GameObject> missilePool;


    public int maxShots;

    // Start is called before the first frame update
    void Start()
    {
        BuildPool();
    }


    private void BuildPool()
    {
        shotPool = new Queue<GameObject>();
        missilePool = new Queue<GameObject>();


        for (int i = 0; i < maxShots; i++)
        {
            var tempShot = Instantiate(normalPhaser, new Vector3(0,0,0), new Quaternion(0,0,0,0));
            tempShot.SetActive(false);
            tempShot.GetComponent<ProjectileMotion>().id = 0;
            shotPool.Enqueue(tempShot);
        }

        for (int i = 0; i < 10; i++)
        {
            var tempShot = Instantiate(normalMissile, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            tempShot.SetActive(false);
            tempShot.GetComponent<ProjectileMotion>().id = 1;
            missilePool.Enqueue(tempShot);
        }

    }

    public GameObject GetShot(Vector3 position, Quaternion rotation)
    {
        //Debug.Log("FIRING");
        var newShot = shotPool.Dequeue();
        newShot.SetActive(true);
        newShot.transform.position = position;
        newShot.transform.rotation = rotation;
        newShot.transform.localScale = scaleModifier;
        newShot.GetComponent<ProjectileMotion>().Fire();
        return newShot;
    }
    public GameObject GetShot2(Vector3 position, Quaternion rotation)
    {
        //Debug.Log("FIRING");
        if(missilePool.Count == 0)
        {
            return null;
        }

        var newShot = missilePool.Dequeue();
        newShot.SetActive(true);
        newShot.transform.position = position;
        newShot.transform.rotation = rotation;
        newShot.transform.localScale = scaleModifier;
        newShot.GetComponent<ProjectileMotion>().Fire();
        return newShot;
    }


    public void Reload(GameObject shot)
    {
        shot.SetActive(false);
        if (shot.GetComponent<ProjectileMotion>().id == 0)
        {
            shotPool.Enqueue(shot);
        }
        if (shot.GetComponent<ProjectileMotion>().id == 1)
        {
            missilePool.Enqueue(shot);
        }
    }

}
