using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject mobPrefab;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnRadius = 15f;
    private GameObject target;

    void Start()
    {
        target = GameObject.Find("Player");
        StartCoroutine("SpawnMob");
    }

    private void Update()
    {
        transform.position = target.transform.position;
    }

    IEnumerator SpawnMob()
    {
        while (true) {
            Vector2 pos = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = (Vector3) pos * spawnRadius + target.transform.position;

            var mob = Instantiate(mobPrefab, spawnPos, Quaternion.identity);
            mob.transform.parent = transform.parent;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
