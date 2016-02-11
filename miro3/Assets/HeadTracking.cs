using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
public class HeadTracking : MonoBehaviour
{
   // public GameObject player; // First Person Controller parent node
   // public GameObject head; // First Person Controller camera

    // The initials orientation
    private float initialOrientationX;
    private float initialOrientationY;
    private float initialOrientationZ;

    // Use this for initialization
    void Start()
    {
        // Activate the gyroscope
        Input.gyro.enabled = true;

        // Save the firsts values
        initialOrientationX = Input.gyro.rotationRateUnbiased.x;
        initialOrientationY = Input.gyro.rotationRateUnbiased.y;
        initialOrientationZ = -Input.gyro.rotationRateUnbiased.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the player and head using the gyroscope rotation rate
        //player.transform.Rotate(0, initialOrientationY - Input.gyro.rotationRateUnbiased.y, 0);
        //head.transform.Rotate(0, initialOrientationY - Input.gyro.rotationRateUnbiased.y,0);
        gameObject.transform.Rotate(0, initialOrientationY - Input.gyro.rotationRateUnbiased.y, 0);
        //게임 오브젝트 전체가 회전해야 회전축을 하나로 설정되어 fowrod가 제대로 적용됨
        
    }
}