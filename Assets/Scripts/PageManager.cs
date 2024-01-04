using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;

    public FirstPersonMovement fpm;
    public Enemy2 enemy2;
    public List<AudioClip> scareSounds;
    public AudioClip pageSound;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Page"))
        {
            RandomScareNoise();
            source.PlayOneShot(pageSound);

            pages++;
            Destroy(other.gameObject);
            
            // Gain Target
            if (pages == 1)
            {
                enemy.target = transform;
            }
            // Increase Speed
            if (pages == 2)
            {
                enemy.speed *= 2;
            }
            // Increase View Distance
            if (pages == 3)
            {
                enemy.viewDistance += 5;
            }
            // Increase View Distance and speed
            if (pages == 4)
            {
                enemy.viewDistance += 15;
                enemy.speed *= 1.25f;
            }
            // Increase View Distance and speed + add a new enemy
            if (pages == 5)
            {
                source.PlayOneShot(scareSounds[0]);
                enemy2.gameObject.SetActive(true);
                enemy.viewDistance += 20;
                enemy.speed *= 1.1f;
            }
            // Increase View Distance and speed of both + handycap
            if (pages == 6)
            {
                fpm.runSpeed -= 2f;
                fpm.speed -= 2f; 
                enemy.viewDistance += 25;
                enemy.speed *= 1.1f;
                enemy2.viewDistance += 50;
                enemy2.speed *= 2f;
            }
            // Can be found anywhere
            if (pages == 7)
            {
                enemy.viewDistance += 1000;
                enemy.speed *= 2f;
                enemy2.viewDistance += 1000;
                enemy2.speed *= 2f;
            }
        }

        void RandomScareNoise()
        {
            int rand = Random.Range(0, scareSounds.Count);
            source.PlayOneShot(scareSounds[rand]);
        }

    }
}
