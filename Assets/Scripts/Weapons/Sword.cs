using UnityEngine;

public class Sword : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=sPiVz1k-fEs
    //--->

    [SerializeField] private GameObject swordAttackPoint;

    //Gets enemy GameObject
    [SerializeField] private GameObject enemyPrefab;

    //Devines the middel of the area of attack
    [SerializeField] private Transform attackPoint;

    //Sets the attack range
    [SerializeField] private float attackRange = 1;

    //Lets you set the attack key
    public KeyCode attackKey = KeyCode.Space;

    //Devines if you can attack
    private bool canAttack = true;

    //Devines what the weapon can collide with
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            //Makes the area of attack and attacks
            Collider[] hitEnemies =
            Physics.OverlapSphere(
                attackPoint.position,
                attackRange,
                enemyLayers
            );

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Damagable>().TakeSwordDamage();

            }
        }
    }
    //<---
}
