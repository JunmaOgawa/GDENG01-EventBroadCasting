using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubeTemplate;
    [SerializeField] private List<GameObject> cubeList;

    void Start()
    {
        this.cubeTemplate.SetActive(false);
        EventBroadcaster.Instance.AddObserver("SPAWN_CUBE", this.SpawnCube);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver("SPAWN_CUBE");
    }

    private void SpawnCube(Parameters parameters)
    {
        int nSpawn = parameters.GetIntExtra("NUM_CUBES_KEY", 1);

        for (int i = 0; i < nSpawn; i++)
        {
            GameObject instance = GameObject.Instantiate(this.cubeTemplate, this.transform);
            instance.SetActive(true);
            this.cubeList.Add(instance);
        }
        
    }
}
