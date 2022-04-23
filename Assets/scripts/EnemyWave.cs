using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FloatEnemyPair
{
    public enemy Enemy;
    public float Timer;
    public Vector3 StartPosition;
}

public class EnemyWave : MonoBehaviour
{
    [SerializeField]
    List<FloatEnemyPair> enemiesPrefab;

    List<enemy> enemies = new List<enemy>();

    float passedTime;
    int index = 0;

    public bool IsDone { get { return isDone; } }
    private bool isDone = false;

    public bool IsDeployed { get { return isDeployed; } }
    private bool isDeployed = false;

    // Update is called once per frame
    void Update()
    { 
        while (index < enemiesPrefab.Count && enemiesPrefab[index].Timer <= passedTime)
        {
            enemies.Add(Instantiate(enemiesPrefab[index].Enemy, enemiesPrefab[index].StartPosition, Quaternion.identity));
            passedTime = 0.0f;
            index++;
        }

        if (index >= enemiesPrefab.Count)
            isDeployed = true;

        passedTime += Time.deltaTime;

        if (isDeployed)
        {
            isDone = true;

            foreach (var item in enemies)
            {
                if (item.Alive == true)
                {
                    isDone = false;
                    break;
                }
            }

            if (isDone)
            {
                foreach (var item in enemies)
                {
                    Destroy(item.gameObject);
                }
                enemies.Clear();
                enabled = false;
            }
        }

    }
}
