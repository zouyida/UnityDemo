using System;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    public GameObject wallLeft;
    public GameObject wallRight;
    public GameObject wallUp;
    public GameObject wallDown;
    [Range(20, 100)]
    public float horizontalLength;
    [Range(20, 100)]
    public float verticalLength;

    private void OnValidate()
    {
        SetLength();
    }
    private void SetLength()
    {
        wallLeft.transform.position = new Vector3(-horizontalLength / 2, 0, 0);
        wallRight.transform.position = new Vector3(horizontalLength / 2, 0, 0);  
        wallUp.transform.position = new Vector3(0, -verticalLength / 2, 0);
        wallDown.transform.position = new Vector3(0, verticalLength / 2, 0);    
    }
}
