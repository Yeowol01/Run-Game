using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;
    [SerializeField] GameObject[] vehicleObject;

    [SerializeField] List<GameObject> vehicleList;

    [SerializeField] int random;
    [SerializeField] int compare = -1;
    [SerializeField] int randomPosition;

    void Start()
    {
        vehicleList.Capacity = 20;

        Create();

        StartCoroutine(ActiveVehicle());
    }

    public void Create()
    {
        for (int i = 0; i < vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i]);

            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                random = Random.Range(0, vehicleObject.Length - 1);

                while (vehicleList[random].activeSelf == true)
                {
                    

                    random = (random + 1) % vehicleObject.Length;
                }

                // 랜덤으로 위치를 설정하는 변수를 선언합니다.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // 만약에 내가 이전에 저장되어 있던 변수와 다시 뽑은 randomPosition의 값이 compare 변수와 일치하다면 중복이 되지 않도록 계산합니다.
                if(compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % spawnPosition.Length;
                }

                // compare 변수와 random으로 설정된 변수의 값을 넣어줍니다.
                compare = randomPosition;

                // vehicle 오브젝트가 활성화되는 위치를 랜덤으로 설정합니다.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // 랜덤으로 설정된 vehicle 오브젝트를 활성화합니다.
                vehicleList[random].SetActive(true);               
            }

            yield return new WaitForSeconds(5);
        }
    }
}
