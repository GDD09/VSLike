using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject mob;
    public Rigidbody2D target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        StartCoroutine("spawn");
    }

    private void Update()
    {
        transform.position = target.position;
    }

    IEnumerator spawn()
    {
        while(true) {
            Vector2 pos = Random.insideUnitCircle.normalized;
            Vector3 spawn_pos = new Vector3(pos.x*20+transform.position.x, pos.y*20+transform.position.y, 0);
            Instantiate(mob, spawn_pos, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
