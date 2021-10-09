using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineMov : MonoBehaviour
{
    public Transform spine;
    public float horzMovment;
    float prevSpineX;
    float prevSpineZ;
    private void Awake()
    {
        prevSpineX = spine.localEulerAngles.x;
        prevSpineZ = spine.localEulerAngles.z;
    }

    void Update()
    {
        horzMovment = -Input.GetAxis("Mouse Y");
    }

    private void LateUpdate() {
        //Rotação da espinha com a camera com a limitação de nao quebrar a coluna
        if(Input.GetMouseButton(1)){
            spine.localRotation = Quaternion.Euler(Mathf.Clamp(prevSpineX + horzMovment * 5, -18, 40), spine.localEulerAngles.y + 12, Mathf.Clamp(prevSpineZ + horzMovment * 5, -18, 40));
            prevSpineX = prevSpineX + horzMovment * 5;
            prevSpineZ = prevSpineZ + horzMovment * 5;
        }else{
            prevSpineX = prevSpineX + horzMovment * 5;
            prevSpineZ = prevSpineZ + horzMovment * 5;
        }
    }
}
