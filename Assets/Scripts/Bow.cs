using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bow : MonoBehaviour
{
    //Arrow Rigidbody
    public Rigidbody arrowPrefabs;

    //Circle GameObject
    public GameObject cursor;

    //Layer Mask
    public LayerMask layer;


    public Transform arrowSpawnPoint;

    //The Line Render
    public LineRenderer lineVisual;


    public int lineSegment = 10;

    //Store the camera
    private Camera cam;


    public bool PlayerFire = true;

    // Start is called before the first frame update
    void Start()
    {
        //make sure camera has the MainCamera tag
        cam = Camera.main;
        lineVisual.positionCount = lineSegment;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //If the raycast hits something
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 vo = CalculateVelocity(hit.point, arrowSpawnPoint.position, 1f);

            Visualize(vo);

            transform.rotation = Quaternion.LookRotation(vo);

            if (Input.GetMouseButtonDown(0))
            {
                if (PlayerFire)
                {
                    Rigidbody obj = Instantiate(arrowPrefabs, arrowSpawnPoint.position, Quaternion.identity);
                    obj.velocity = vo;

                    PlayerFire = false;
                    StartCoroutine(Wait());
                }

            }
        }
        else
        {
            cursor.SetActive(false);
        }
    }

    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float)(lineSegment));
            lineVisual.SetPosition(i, pos);
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //create a float the represent our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        //Calculate the velocity 
        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }

    

    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        //Set the x, z, and y position 
        Vector3 result = arrowSpawnPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + arrowSpawnPoint.position.y;

        result.y = sY;

        return result;
    }

    IEnumerator Wait()
    {
        PlayerFire = false;

        yield return new WaitForSeconds(0.5F);

        PlayerFire = true;
    }


}
