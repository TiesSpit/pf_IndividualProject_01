using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField] private GameObject healthPickup;
    [SerializeField] private GameObject speedIncreasePickup;
    [SerializeField] private GameObject gun;
    
    public int currentPlayerHealth = 100;

    //The amount of damage the player does
    public int playerDamage = 25;
    //The amount of damage the enemies do
    public int enemyDamage = 20;

    private int enemyHealth = 100;

    //Time for how long you cant take damage after being hit
    private float invisTime;
    //Timer to take track of invinsibility cooldown
    private float invisCooldown = 0;


    //This will be set to a random number when an enemy dies and decide if it will spawn a pickup
    float pickupDropChance;
    //This will be set to a random number when a pickup is dropped and decide which pickup it will be
    float whichPickupChance;

    //The amount of health you gain when getting healthPickup
    public int healthPickupAmount = 10;
    //The amount by which your attackspeed will increse when getting speedIncreasePickup

    //Check if you can take damage
    [SerializeField] private bool canTakeDamage = true;


    //Source: https://www.youtube.com/watch?v=pz98OtOid5U
    //--->    
    public UnityEvent OnHealthChanged;
    //<---


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTakeDamage)
        {
            //track invinsibility time and count down
            invisCooldown += Time.deltaTime;
            if (invisCooldown >= invisTime)
            {
                canTakeDamage = true;
            }
        }
    }

    //Tracks dammage
    private void OnCollisionEnter(Collision collision)
    {

        if (canTakeDamage) 
        {

            //Checks if the hit object is an enemy and if the enemy is hit with a weapon
            if (gameObject.layer == 7 && collision.gameObject.tag == "Weapon")
            {
                //Debug.Log("Hit");
                enemyHealth -= playerDamage;             
            }




            //Checks if the hit object is the player
            if (gameObject.tag == "Player" && collision.gameObject.layer == 7)
            {                                
                //Debug.Log("Hit");
                currentPlayerHealth -= enemyDamage;
                invisCooldown = 0;
                canTakeDamage = false;                

                //Source: https://www.youtube.com/watch?v=pz98OtOid5U
                //--->
                OnHealthChanged.Invoke();
                //<---
            }

            //Checks if the player collects a pickup
            if (gameObject.tag == "Player" && collision.gameObject.layer == 9)
            {      
                if (collision.gameObject.tag == "HealthPickup")
                {
                    currentPlayerHealth += healthPickupAmount;

                    //Source: https://www.youtube.com/watch?v=pz98OtOid5U
                    //--->
                    OnHealthChanged.Invoke();
                    //<---
                }
                else if (collision.gameObject.tag == "SpeedPickup")
                {
                    gun.GetComponent<Gun>().shootCooldown /= 1.25f;
                }
            }
            //Checks if a pickup is picked up and deletes it
            if (gameObject.layer == 9)
            {
                Destroy(gameObject);
            }

            //Kills the player or enemy if their health = 0
            if (currentPlayerHealth <= 0 || enemyHealth <= 0)
            {
                pickupDropChance = Random.Range(1, 5);
                if (pickupDropChance <= 2)
                {
                    whichPickupChance = Random.Range(1, 5);
                    if (whichPickupChance <= 2)
                    {
                        Instantiate(
                            speedIncreasePickup,
                            transform.position,
                            speedIncreasePickup.transform.rotation
                        );
                    }
                    else
                    {
                        Instantiate(
                            healthPickup,
                            transform.position,
                            healthPickup.transform.rotation
                        );
                    }
                }
                GameManager.instance.ObjectWasDestroyed(gameObject);

                Destroy(gameObject);
            }
        }
    }

    //Damage tracker for the sword attack
    //Source: https://www.youtube.com/watch?v=sPiVz1k-fEs
    //--->
    public void TakeSwordDamage()
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= playerDamage;
        }

        //Kills the player or enemy if their health = 0
        if (enemyHealth <= 0)
        {
            pickupDropChance = Random.Range(1, 5);
            if (pickupDropChance <= 2)
            {
                whichPickupChance = Random.Range(1, 5);
                if (whichPickupChance <= 2)
                {
                    Instantiate(
                        speedIncreasePickup,
                        transform.position,
                        speedIncreasePickup.transform.rotation
                    );
                }
                else
                {
                    Instantiate(
                        healthPickup,
                        transform.position,
                        healthPickup.transform.rotation
                    );
                }
            }
            GameManager.instance.ObjectWasDestroyed(gameObject);

            Destroy(gameObject);
        }
    }
    //<---
}
