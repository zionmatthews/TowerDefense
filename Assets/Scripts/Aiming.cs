using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-speed, 0, 0);
        }
    }
    /* This class will be how the player aims up and down. Maybe left and right. At this moment. I'm using simple rotation to move the "bow" up and down to shoot
     * at the bottom of the tower. I'm thinking of implementing 360 movement for the player so the player can look anywhere with just using the mouse. but that might be difficult
     * implementation wise and gameplay wise. So this just might be the best thing.*/
}
