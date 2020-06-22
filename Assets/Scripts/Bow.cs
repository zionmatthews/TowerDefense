using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    float _charge;

    //Max charge
    public float chargeMax;

    //The rate in which it takes to get max
    public float chargeRate;

    //Fire Key
    public KeyCode fireButton;

    public Transform arrowSpawnPoint;

    
    //Arrow Rigidbody
    public Rigidbody arrowObj;

    //Player Fire rate
    bool PlayerFire = true;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(fireButton) && _charge < chargeRate)
        {
            //fire button is hold, charge the bow.
            _charge += Time.deltaTime * chargeRate;
            Debug.Log(_charge.ToString());
           
        }
       
        if (Input.GetKeyUp(fireButton))
        {
            if (PlayerFire)
            {
                //Arrow fires in the straight position from the ArrowSpawnPoint.
                Rigidbody arrow = Instantiate(arrowObj, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation) as Rigidbody;
                arrow.AddForce(arrowSpawnPoint.forward * _charge, ForceMode.Impulse);
                //Reset charge
                _charge = 0;
                StartCoroutine(Wait());
            }
           
        }
    }   
    IEnumerator Wait()
    {
       PlayerFire = false;

       yield return new WaitForSeconds(1);

        PlayerFire = true;
    }
  
}
