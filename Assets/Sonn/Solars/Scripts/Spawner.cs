using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Sonn.Solars
{
    public class Spawner : MonoBehaviour
    {

        [Tooltip("The Prefab to be spawned into the scene.")]
        public GameObject spawnPrefab = null;
        public List<Material> materialsComet;

        [Tooltip("The time between spawns")]
        public float spawnTime = 5.0f;

        // keep track of time passed for next spawn
        private float nextSpawn = 0f;

        // Start is called before the first frame update
        void Start()
        {
            nextSpawn = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            // update the time until nextSpawn
            nextSpawn += Time.deltaTime;

            // if time to spawn
            if (nextSpawn > spawnTime)
            {
                // Spawn the gameObject at the spawners current position and rotation
                var newComet = Instantiate(spawnPrefab, transform.position, transform.rotation, null);
                
                if (newComet)
                {
                    newComet.transform.SetParent(transform, false);
                    if (materialsComet.Count > 0)
                    {
                        var rand = RandomNumberGenerator.GetInt32(0, materialsComet.Count);
                        var mat = materialsComet[rand];
                        var renderer = newComet.GetComponent<Renderer>();
                        if (renderer)
                        {
                            renderer.material = mat;
                        }
                    }
                }    
                // reset the time until nextSpawn
                nextSpawn = 0f;
            }

        }
    }

}
