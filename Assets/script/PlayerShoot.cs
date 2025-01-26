
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // prefab peluru
    public Transform spawnPoint; // titik spawn peluru
    public float projectileSpeed = 25f; // kecepatan peluru

    private void Update()
    {
        // Memeriksa jika tombol fire1 (mouse kiri atau tombol lain yang ditentukan) ditekan
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Membuat peluru dari prefab di spawnPoint
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        // Menambahkan kecepatan pada peluru dengan Rigidbody2D
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Mengatur kecepatan peluru ke arah yang sesuai (biasanya ke kanan jika spawnPoint menghadap ke kanan)
            rb.velocity = spawnPoint.right * projectileSpeed;
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // prefab peluru
    public Transform spawnPoint; // titik spawn peluru
    public float projectileSpeed = 10f; // kecepatan peluru
    public float destroyObjet;

    private void Update()
    {
        // Memeriksa jika tombol fire1 (mouse kiri atau tombol lain yang ditentukan) ditekan
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Membuat peluru dari prefab di spawnPoint
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);


        // Menambahkan kecepatan pada peluru dengan Rigidbody2D
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            // Mengatur kecepatan peluru ke arah yang sesuai (biasanya ke kanan jika spawnPoint menghadap ke kanan)
            rb.velocity = spawnPoint.right * projectileSpeed;
        }
    }
}





