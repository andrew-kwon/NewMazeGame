using UnityEngine;
using System.Collections;


public class moving : MonoBehaviour
{
    public float speed = 5.0f;        // moving speed
    private bool hasChanged =true;
    private int counter=0;
    private int guiCounter = 0;
    float x_old = 0;
    float y_old = 0;
    float z_old = 0;

    void movingforward(float amtToMove,int checkCounter) //moving smoothing
    {
        transform.Translate(Vector3.forward * checkCounter * 5 * amtToMove);
    }
    void Update()
    {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;

        float oldValue=(x_old*x)+(y_old*y)+(z_old*z);
        float oldValueSqrt = Mathf.Abs(Mathf.Sqrt(oldValue));
        float newValue = Mathf.Abs(Mathf.Sqrt((x * x) + (y * y) + (z * z)));

        oldValue = oldValueSqrt * newValue;

        if ((oldValue <= 0.8) && (oldValue > 0.7)) //민감도 조절
        {
            if (!hasChanged)
            {
                hasChanged = true;
                counter++;
                guiCounter++;
            }
            else
                hasChanged = false;
        }
        x_old = x;
        y_old = y;
        z_old = z;

        float amtToMove = speed * Time.deltaTime;  // moving distance per frame
        movingforward(amtToMove,counter);
        // 진동을 감지하면 그 순간에 움직임.
        counter = 0;
    }
    void OnGUI()
    {
        GUILayout.TextArea(" counter  : " + guiCounter);
        // 어느정도의 민감도 체크
      
    }

}
