using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class attack_state : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            if(shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            if(moveTimer >Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                StateMachine.ChangeState(new searchState());
            }

        }
    }

    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/pelor") as GameObject, gunbarrel.position, gunbarrel.rotation);

        // Arah tembakan menuju player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.position).normalized;

        // Variasi kecil pada arah tembakan
        shootDirection = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootDirection * 40f;

        // Atur deteksi tabrakan peluru
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Debug untuk memverifikasi arah
        Debug.DrawRay(gunbarrel.position, shootDirection * 40f, Color.red, 1f);

        // Reset timer untuk tembakan berikutnya
        shootTimer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



