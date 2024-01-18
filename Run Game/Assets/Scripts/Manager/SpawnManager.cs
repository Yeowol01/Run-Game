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

                // �������� ��ġ�� �����ϴ� ������ �����մϴ�.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // ���࿡ ���� ������ ����Ǿ� �ִ� ������ �ٽ� ���� randomPosition�� ���� compare ������ ��ġ�ϴٸ� �ߺ��� ���� �ʵ��� ����մϴ�.
                if(compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % spawnPosition.Length;
                }

                // compare ������ random���� ������ ������ ���� �־��ݴϴ�.
                compare = randomPosition;

                // vehicle ������Ʈ�� Ȱ��ȭ�Ǵ� ��ġ�� �������� �����մϴ�.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // �������� ������ vehicle ������Ʈ�� Ȱ��ȭ�մϴ�.
                vehicleList[random].SetActive(true);               
            }

            yield return new WaitForSeconds(5);
        }
    }
}
