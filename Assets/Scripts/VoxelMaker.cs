using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;
    public int voxelPoolSize = 20;




    void Update()
    {
        if (Input.GetButtonDown("Fire1")||Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject voxel = Instantiate(voxelFactory);
                voxel.transform.position = hitInfo.point;
            }
        }
    }
}
