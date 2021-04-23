using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.transform.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
