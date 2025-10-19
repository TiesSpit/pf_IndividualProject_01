using UnityEngine;

public class LookDirection : MonoBehaviour
{
    //Source https://stackoverflow.com/questions/55228561/unity-having-the-player-face-the-mouse-direction-why-does-this-code-work  
    //--->
    [SerializeField] private Camera mainCam;


    // Update is called once per frame
    void Update()
    {
        Vector3 input = Input.mousePosition;
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(new Vector3(input.x, input.y, mainCam.transform.position.y));
        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }
    //<---
}
