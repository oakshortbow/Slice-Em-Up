using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnRoom : MonoBehaviour {
    private RoomTemplates templates;
    private int rand;
    private GameObject[] roomCount;
    // Use this for initialization
    void Start () { 
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomCount = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Spawn();
    }
	
	// Update is called once per frame
	void Spawn () {
        rand = Random.Range(0, templates.Rooms.Length);
        if (roomCount.Length < templates.roomsToSpawn)
        {
           Instantiate(templates.Rooms[rand], transform.position, templates.Rooms[rand].transform.rotation);
        }
        else
        {
            Instantiate(templates.endRooms[0], transform.position, templates.endRooms[0].transform.rotation);
        }
    }
    
}
