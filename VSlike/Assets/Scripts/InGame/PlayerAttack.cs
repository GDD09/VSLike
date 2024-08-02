using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// WIP
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject atk_range;
    [SerializeField] private Rigidbody2D player_pos;
    void Start()
    {
        player_pos = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    IEnumerator attack(int cooldown)
    {
        while (true)
        {
            Instantiate(atk_range, new Vector3(player_pos.position.x, player_pos.position.y, 0) + Input.mousePosition, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
