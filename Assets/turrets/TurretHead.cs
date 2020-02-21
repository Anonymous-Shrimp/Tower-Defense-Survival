using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    public Transform turhetNose;
    public GameObject[] yenemy;
    public string EnemyTag = "Enemy";
    [Space]
    public GameObject projectile;
    public float shootRate = 5f;
    float timer = 0;
    public Transform baseBase;

    // Start is called before the first frame update
    void Start()
    {
        baseBase = GameObject.Find("Base").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        yenemy = GameObject.FindGameObjectsWithTag(EnemyTag);
        float closest = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject toScan in yenemy)
        {
            float distanse = Vector3.Distance(baseBase.position, toScan.transform.position);
            if (distanse < closest)
            {
                closest = distanse;
                closestEnemy = toScan;
            }

        }
        if (closestEnemy != null)
        {
            transform.LookAt(closestEnemy.transform);
            if(timer <= 0)
            {
                Instantiate(projectile, turhetNose.position, transform.rotation);
                timer = 100;
            }
            else
            {
                timer -= shootRate / Time.deltaTime;
            }

        }

    }
    

}
