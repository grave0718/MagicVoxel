using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5;
    float currentTime = 0;
    public float destroyTime = 3f;

    void OnEnable()
    {

        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //system, unityengine 라이브러리 둘다 쓰면 둘중 어디에서 무슨 랜덤을 가져와야할지 모르기 때문에 오류 발생, 어떤 랜덤을 사용할지 지정해줘야함
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
        
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > destroyTime)
        {
            gameObject.SetActive(false);
            VoxelMaker.voxelPool.Add(gameObject);
            
        }
    }


}
