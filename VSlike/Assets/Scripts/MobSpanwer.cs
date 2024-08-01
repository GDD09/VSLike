using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject mob;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    // Update is called once per frame

    IEnumerator spawn()
    {
        while(true) {
            Vector2 pos = Random.insideUnitCircle * 10;
            Vector3 spawn_pos = new Vector3(pos.x, pos.y, 0);
            Instantiate(mob, spawn_pos, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
