using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Init
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

	// called once per frame and when everything is processed
	void LateUpdate()
	{
            transform.position = player.transform.position + offset;
	}
}