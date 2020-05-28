using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public GameObject levelCloud;
    public GameObject RightCloud;

    float time;

    float speed = 10.0f;

    bool isDown = false;

    void Update()
    {
        /*
         * right - z축을 움직이면 된다. 480 이 되면 -200로 움직이면 된다.
         * level 움직임 - -15부터 -10까지
         */

        time += Time.deltaTime;
        if (RightCloud.transform.position.z < 400.0f)
        {
            RightCloud.transform.Translate(Vector3.forward * (speed/2) * Time.deltaTime);
        }
        else
        {
            RightCloud.transform.position = new Vector3(0, -10, -200);
        }

        if (levelCloud.transform.position.y>-10.0f)
        {
            isDown = true;
        }
        else if(levelCloud.transform.position.y < -15.0f)
        {
            isDown = false;

        }

        if (isDown)
        {
            levelCloud.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            levelCloud.transform.Translate(Vector3.up * (speed / 2) * Time.deltaTime);

        }




    }
}
