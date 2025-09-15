using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle;
    public float sensitivity = 200;

    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
        
    }


    void Update()
    {
        //마우스 입력
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        //이동방향 별 회전 값 누적
        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;
        
        angle.x = Mathf.Clamp(angle.x,-90,90);
        //실제 회전
        transform.eulerAngles = new Vector3(-angle.x, angle.y, transform.eulerAngles.z);

    }
}
