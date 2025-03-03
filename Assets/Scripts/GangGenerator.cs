using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GangGenerator : MonoBehaviour
{
    public int prefabNumber = 5;
    public Vector2 center = Vector2.zero;
    public Vector2 mapSize = new Vector2(50, 50);
    public float minDistance = 10f;
    private Bounds bounds;

    public GameObject EnemyHivePrefab;
    public GameObject EnemyPrefab;

    private List<GameObject> spawnedGangs= new List<GameObject>();
    private List<GameObject> randomEnemies = new List<GameObject>();

    //Instantiate(prefab, position, rotation, parent);
    private void Start()
    {
        MapBorder();
        EnemyHivePrefab = Resources.Load<GameObject>("enemy");

        EnemyHivePrefab = Resources.Load<GameObject>("EnemyGang");
        InstantiateEnemyGang(prefabNumber);
        RandomEnemyChilds(5);
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
        foreach (GameObject go in spawnedGangs)
        {
            int enemies = Random.Range(1, difficulty);
            for (int i = 0; i < enemies; i++)
            {
                // Yeni enemy objesi oluþtur
                GameObject enemy = Instantiate(EnemyPrefab, go.transform.position, Quaternion.identity, go.transform);

                // Düþmaný biraz rastgele konumlandýr (Ayný noktaya üst üste spawn olmamasý için)
                enemy.transform.position += (Vector3)Random.insideUnitCircle * 2f;
            }
        }
    }
}
