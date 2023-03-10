using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationScript : MonoBehaviour
{
    public List<GameObject> ChangePositionOnRotate = new List<GameObject>();

    public List<Transform> OnAlbumOrientation = new List<Transform>();
    public List<Transform> OnPortretOrientation = new List<Transform>();

    public DeviceOrientation lastOrient;

    public bool isFirstCamera;

    public float CameraPortretSize;
    public float CameraAlbumSize;

    private void Start()
    {
        lastOrient = Input.deviceOrientation;
    }

    private void Update()
    {
        DeviceOrientation Orientation = Input.deviceOrientation;

        if (lastOrient != Orientation)
        {
            if(Orientation == DeviceOrientation.Portrait)
            {
                for(int i = 0; i < ChangePositionOnRotate.Count; i++)
                {
                    ChangePositionOnRotate[i].transform.position = OnPortretOrientation[i].position;
                    ChangePositionOnRotate[i].transform.rotation = OnPortretOrientation[i].rotation;
                }

                if (isFirstCamera)
                {
                    ChangePositionOnRotate[0].GetComponent<Camera>().orthographicSize = CameraPortretSize;
                }
            }
            else if (Orientation == DeviceOrientation.LandscapeLeft || Orientation == DeviceOrientation.LandscapeRight)
            {
                for (int i = 0; i < ChangePositionOnRotate.Count; i++)
                {
                    ChangePositionOnRotate[i].transform.position = OnAlbumOrientation[i].position;
                    ChangePositionOnRotate[i].transform.rotation = OnAlbumOrientation[i].rotation;
                }

                if (isFirstCamera)
                {
                    ChangePositionOnRotate[0].GetComponent<Camera>().orthographicSize = CameraAlbumSize;
                }
            }
            lastOrient = Orientation;
        }
    }
}
