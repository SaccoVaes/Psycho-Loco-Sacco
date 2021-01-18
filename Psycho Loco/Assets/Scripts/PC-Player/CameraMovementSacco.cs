using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSacco : MonoBehaviour
{
    public GameObject camerarig;
    public GameObject camera;
 private float currentZoom = 10f;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position, camera.transform.forward * 100, Color.green);
        if (Input.GetKey("w"))
        {
            camerarig.transform.Translate(0, 0, 1,Space.Self);
        }

        if (Input.GetKey("s"))
        {
            camerarig.transform.Translate(0, 0, -1,Space.Self);
        }

        if (Input.GetKey("a"))
        {
            camerarig.transform.Translate(-1, 0, 0, Space.Self);
        }

        if (Input.GetKey("d"))
        {
            camerarig.transform.Translate(1, 0, 0, Space.Self);
        }

        //checks if the user scrolls up AKA zooming in!

        if (Input.mouseScrollDelta.y > 0 && camerarig.transform.position.y >= 5.0)
        {
            //Move the camerarig along the z-axis of the camera.
            camerarig.transform.Translate(0,0,1,camera.transform);
        }

        //checks if the user scrolls down
        if (Input.mouseScrollDelta.y < 0 )
        {
            camerarig.transform.Translate(0, 0, -1, camera.transform);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                print("Found an object - distance: " + hit.distance);
                camerarig.transform.RotateAround(hit.point, Vector3.up, 90 * Time.deltaTime);
            }
            //camerarig.transform.Rotate(new Vector3(0,1,0),Space.World); 
        }


        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                print("Found an object - distance: " + hit.distance);
                camerarig.transform.RotateAround(hit.point, Vector3.up, -90 * Time.deltaTime);
            }
            //camerarig.transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }

        if (Input.GetKey(KeyCode.Z) && camera.transform.rotation.eulerAngles.x < 90) 
        {
            camera.transform.Rotate(new Vector3(1, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.X) && camera.transform.rotation.eulerAngles.x > 30)
        {
            camera.transform.Rotate(new Vector3(-1, 0, 0), Space.Self);
        }
    }

    // Returns a Vector3 with only the X and Z components (Y is 0'd)
    public Vector3 vector3XZOnly(Vector3 vec)
    {
        return new Vector3(vec.x, 0f, vec.z);
    }
}
