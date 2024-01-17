using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{  
    [SerializeField] Transform  [] spawnPosition;
    [SerializeField] GameObject [] vehicleObject;

    [SerializeField] List<GameObject> vehicleList;

    [SerializeField] int count;
    [SerializeField] int random;
    [SerializeField] int randomPosition;

    void Start()
    {
        vehicleList.Capacity = 20;

        Create();
    }

    public void Create()
    {
        for(int i = 0; i < vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i]);

            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            random = Random.Range(0, vehicleObject.Length);

            while (vehicleList[random].activeSelf == true)
            {
                count++;

                if(count >= vehicleObject.Length)
                {
                    yield break;
                }

                random = (random + 1) % vehicleObject.Length;
            }

            vehicleList[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }
}
