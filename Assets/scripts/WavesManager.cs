using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatEnemyWavePair
{
    public EnemyWave Wave;
    public float Timer;
}

public class WavesManager : MonoBehaviour
{
    [SerializeField]
    List<FloatEnemyWavePair> waves;

    List<int> currentWaves;

    float passedTime;

    public bool IsDone { get { return waves.Count == wavesDone; } }
    int wavesDone = 0;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentWaves = new List<int>();

        foreach (var item in waves)
        {
            item.Wave.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index < waves.Count)
        {
            if (waves[index].Timer != 0.0f)
            {
                if (waves[index].Timer <= passedTime && waves[index].Timer != 0)
                {
                    waves[index].Wave.enabled = true;
                    currentWaves.Add(index);
                    index++;
                    passedTime = 0;
                }
            }
            else
            {
                if (waves[index - 1].Wave.IsDone)
                {
                    waves[index].Wave.enabled = true;
                    currentWaves.Add(index);
                    index++;
                    passedTime = 0;
                }
            }
        }

        foreach (var item in currentWaves)
        {
            if (waves[item].Wave.IsDone)
            {
                Debug.Log("Wave done");
                wavesDone++;
                
            }
        }
        currentWaves.RemoveAll(x => waves[x].Wave.IsDone);

        if (index == 0)
            passedTime += Time.deltaTime;
        else if (index > 0 && waves[index-1].Wave.IsDeployed)
            passedTime += Time.deltaTime;
    }
}
