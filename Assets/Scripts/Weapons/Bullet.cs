using UnityEngine;

public class Bullet : MonoBehaviour
{

    //Destroys bullet when it hits something
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
