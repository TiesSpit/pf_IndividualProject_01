using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        transform.Translate(
            speed * Time.deltaTime *
            new Vector3(
                Input.GetAxis("Horizontal"),    //Left to right movement
                0,
                Input.GetAxis("Vertical")       //Up and down movement
            ),
            Space.World
        );

 
    }
}
