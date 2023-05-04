using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        //player = GameObject.FindWithTag("Player").transform;
        //transform.SetPositionAndRotation(new Vector3(player.position.x + 4, player.position.y, player.position.z - 10), player.rotation);
        //this.transform.SetParent(player);
    }
    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
            transform.SetPositionAndRotation(new Vector3(player.position.x + 4, player.position.y, player.position.z - 10), player.rotation);
            this.transform.SetParent(player);
        }

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
