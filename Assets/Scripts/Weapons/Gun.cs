using UnityEngine;

public class Gun : MonoBehaviour
{
    // The Rigidbody of the bullet to be instantiated and shot.
    public Rigidbody bulletPrefab;
    // The magnitude of the velocity the bullet will be shot with
    public int  bulletSpeed = 15;
    // The time interval between consecutive shots.
    public float shootCooldown;
    // How long the bullet will live without hitting anything
    public float timeToLive = 2;

    // A boolean to check if the cannon can shoot.
    private bool canShoot = true;
    // A timer to keep track of the cooldown period.
    private float shootTimer = 0;
    // shootkey
    public KeyCode shootKey = KeyCode.None;



    void Update()
    {
        if (canShoot &&
            (Input.GetKey(shootKey) || shootKey == KeyCode.None)
            )
        {
            //Debug.Log("Shoot");
            Rigidbody r = Instantiate(
                bulletPrefab, 
                transform.position, 
                transform.rotation
                );
            r.linearVelocity = transform.forward * bulletSpeed;

            Destroy(r.gameObject, timeToLive);
            canShoot = false;
        }

        // If the gun cannot shoot, start the cooldown timer.
        if (!canShoot)
        {
            // Increase the timer by the time passed since the last frame.
            shootTimer += Time.deltaTime;

            // Check if the cooldown period has passed.
            if (shootTimer >= shootCooldown)
            {
                // Reset the timer and allow the gun to shoot again.
                shootTimer = 0.0f;
                canShoot = true;
            }
        }
    }
}
