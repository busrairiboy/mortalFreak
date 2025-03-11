using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GangGenerator : MonoBehaviour
{
    public int GangNumber = 5;
    public Vector2 center = Vector2.zero;
    public Vector2 mapSize = new Vector2(50, 50);
    public float minDistance = 10f;
    private Bounds bounds;

    public GameObject EnemyHivePrefab;
    public List<GameObject> EnemyPrefab= new List<GameObject>();

    private List<GameObject> spawnedGangs= new List<GameObject>();
    private List<GameObject> randomEnemies = new List<GameObject>();

    //Instantiate(prefab, position, rotation, parent);
    private void Start()
    {
        MapBorder();
        EnemyHivePrefab = Resources.Load<GameObject>("EnemyGang");
        InstantiateEnemyGang(GangNumber);
        RandomEnemyChilds(15);
    }

    public void MapBorder()
    {
        bounds = new Bounds(center, mapSize);
    }

    public List<Vector2> RandomMapLocation(int count)
    {
        List<Vector2> positions = new List<Vector2>();

        while (positions.Count < count)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            Vector2 newPosition = new Vector2(x, y);

            // Çakýþma kontrolü
            bool isValid = true;
            foreach (Vector2 pos in positions)
            {
                //map elementlerinden de uzaklýða göre konumlandýrma yapýlacak
                //player ve kovanýnýn büyüklüðü kadar da uzaklandýrma olacak
                if (Vector2.Distance(pos, newPosition) < minDistance)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                positions.Add(newPosition);
            }
        }

        return positions;
    }

    public void InstantiateEnemyGang(int howMany)
    {
        List<Vector2> positions = RandomMapLocation(howMany);
        foreach (Vector2 pos in positions)
        {
            GameObject gang = Instantiate(EnemyHivePrefab, pos, Quaternion.identity);
            spawnedGangs.Add(gang);
        }
    }

   
    public void RandomEnemyChilds(int difficulty)
    {
        foreach (GameObject gang in spawnedGangs)
        {
            int enemiesCount = Random.Range(1, difficulty);
            for (int i = 0; i < enemiesCount; i++)
            {
                if (EnemyPrefab.Count == 0) return; // Eðer liste boþsa hata almamak için çýkýþ yap

                GameObject randomEnemy = EnemyPrefab[Random.Range(0, EnemyPrefab.Count)];
                GameObject enemy = Instantiate(randomEnemy, gang.transform.position, Quaternion.identity, gang.transform);
                enemy.transform.position += (Vector3)Random.insideUnitCircle * 2f;
            }
        }
    }

}
