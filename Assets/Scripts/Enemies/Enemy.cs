using UnityEngine;

public class Enemy : MonoBehaviour
{    
    //Divines the target for the enemies to follow
    public Transform target;

    [SerializeField] private float enemySpeed;


    //source: https://www.youtube.com/watch?v=XHrWtLZtzy8
    //--->
    private void Awake()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
    }
    //<---

    // Update is called once per frame
    void Update()
    {        
        //Checks if the player is alive
        if (target != null)
        {
            //Makes enemy look at player
            Vector3 displacementToTarget = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(displacementToTarget, Vector3.up);
        }


        if(gameObject.tag == "Enemy")
        {
            //Makes enemy move towards the player
            transform.Translate(
                0,
                0,
                enemySpeed * Time.deltaTime
            );
        }
        else if (gameObject.tag == "GunEnemy")
        {
            //Makes gunEnemy spiral around the player
            transform.Translate(
                enemySpeed * Time.deltaTime,
                0,
                1 * Time.deltaTime
            );
        }
    }
}
