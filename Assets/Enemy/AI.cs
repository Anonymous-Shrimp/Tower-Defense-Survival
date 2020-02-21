using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public GameObject targetBase;
    public GameObject targetPlayer;
    public Transform target;
    public NavMeshAgent agent;
    public GameObject fireball;
    public Transform mouth;
    public float fireballspeed=30;
    public float frequency=1;
    private float currenttime;
 //   public Transform dragonhead;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        float distanseBase = Vector3.Distance(gameObject.transform.position, targetBase.transform.position);
        float distansePlayer = Vector3.Distance(gameObject.transform.position, targetPlayer.transform.position);
        if (distanseBase < distansePlayer)
        {
            target = targetBase.transform;
        }
        else
        {
            target = targetPlayer.transform;
        }


        

            if (currenttime < 20)
            {
                shoot();
                // dragonhead.LookAt(target);
            }
            else
            {
                currenttime = 0;
                //dragonhead.rotation = Quaternion.RotateTowards(dragonhead.rotation, Quaternion.identity, 5 * Time.deltaTime);
            }
            agent.SetDestination(target.position);

        
    }

    public void shoot()
    {
        if(currenttime<=frequency)
        {
            currenttime += Time.deltaTime;
        }
        else
        {
            GameObject clone = Instantiate(fireball, mouth.position, mouth.rotation);
            clone.GetComponent<Rigidbody>().AddForce(mouth.TransformDirection(Vector3.forward) *fireballspeed, ForceMode.Impulse);
            Destroy(clone, 3);
            currenttime = 0;
        }
    }
}
