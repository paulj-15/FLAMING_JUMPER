using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;// drag player into this object
    public float offst;// provide value manually from engine (say 5/6/7)
    private Vector3 PlayPos;
    public float offsetSmooth;// provide value manually from engine (say 0.5/1/2/3)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //2. change transform to playpos
        PlayPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        // 3. if else to manage proper flipping to player
        if (player.transform.localScale.x > 0f)
        {
            PlayPos = new Vector3(PlayPos.x + offst, PlayPos.y, PlayPos.z);
        }
        else
        {
            PlayPos = new Vector3(PlayPos.x - offst, PlayPos.y, PlayPos.z);
        }
        //4. Lerp for smoothly moving the camera in the right direction.
        transform.position = Vector3.Lerp(transform.position, PlayPos, offsetSmooth * Time.deltaTime);

    }
}
