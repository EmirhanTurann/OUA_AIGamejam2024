using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject MainCam;

    private void Update()
    {
        MainCam.transform.position = new Vector3(MainCam.transform.position.x, transform.position.y+4.70f, transform.position.z);
    }
}
