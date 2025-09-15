using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;
    public int voxelPoolSize = 20;
    public float CreateTime = 0.1f;
    float currentTime = 0;
    //<Gameobject>는 제네럴, 리스트 요소의 기본 형태를 정해둠
    //static은 이 코드가 여러번 실행되어 독립되더라도 이 변수는 유일하게 정의
    public static List<GameObject> voxelPool = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)
        {
            GameObject voxel = Instantiate(voxelFactory);
            voxel.SetActive(false);
            
            voxelPool.Add(voxel);


        }

    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > CreateTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (voxelPool.Count > 0)
                {
                    currentTime = 0f;
                    GameObject voxel = voxelPool[0]; //복셀풀에서 첫번째값을 가져옴
                    voxel.SetActive(true);
                    voxel.transform.position = hitInfo.point; //원하는 위치에 생성
                    voxelPool.RemoveAt(0); //복셀풀에서 첫번째값 제거   
                }

            }

        }
    }
}
