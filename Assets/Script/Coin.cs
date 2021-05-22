using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Coin,
    Ticket,
    Point
}

public class Coin : MonoBehaviour
{
    [SerializeField] Type typeOfCoin;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().play("PickUp");
            FindObjectOfType<GameManager>().IncrementScore(typeOfCoin);
    
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
