using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().play("PickUp");
            FindObjectOfType<GameManager>().IncrementScore();
            Debug.Log("coin");
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
	{
        Vector3 pos = transform.position;
        pos.y += 0.01f * Mathf.Sin(4 * Time.time);
        transform.position = pos;
	}
}
