using System.Collections;
using UnityEngine;

public class SafeShooter : Behaviour
{
    private bool isChasing = false;
    private bool isReadyToShoot = false;
    private bool isRunningAway = false;
    private bool isFiringProjectile = false;

    void FixedUpdate()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isChasing && !isRunningAway)
        {
            if (distanceToPlayer < chaseRange)
            {
                // Start chasing the player
                isChasing = true;
            }
        }
        else if (isChasing && !isRunningAway)
        {
            if (distanceToPlayer > chaseRange)
            {
                // Stop chasing if the player is out of range
                isChasing = false;
            }
            else if (distanceToPlayer <= shootingRange)
            {
                // Start shooting the player if within shooting range
                isReadyToShoot = true;
                isRunningAway = false;
            }
            else
            {
                // Continue chasing the player
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
                transform.Translate(0, 0, movementSpeed * Time.deltaTime);
            }
        }
        else if (isReadyToShoot && !isRunningAway)
        {
            if (distanceToPlayer > shootingRange)
            {
                // Stop shooting if the player is out of shooting range
                isReadyToShoot = false;
                if (isFiringProjectile)
                {
                    isFiringProjectile = false;
                    StopCoroutine(
                        handleShooting()); //TODO can be an easy refactor if merge readyToShoot + firing flags 
                }

                isChasing = true;
            }
        }

        // Run away from the player if too close
        if (distanceToPlayer < evadeRange)
        {
            isRunningAway = true;
            Vector3 direction = (transform.position - player.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        }

        // Shoot if in range
        if (isReadyToShoot)
        {
            if (!isFiringProjectile)
            {
                StartCoroutine(handleShooting());
            }
        }
    }

    private IEnumerator handleShooting()
    {
        isFiringProjectile = true;
        while (isFiringProjectile)
        {
            int projectileCounter = 0;
            while (projectileCounter < fireRate)
            {
                fireProjectile();
                projectileCounter++;
                yield return new WaitForSeconds(bulletInterval);
            }

            yield return new WaitForSeconds(reloadTime);
        }
    }

    private void fireProjectile()
    {
        // Instantiate a new bullet object
        GameObject bullet = Instantiate(bulletPrefab, barrelObject.transform.position, barrelObject.transform.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Set the velocity of the bullet to make it travel in a straight line
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

        // Set the lifetime of the bullet
        //Destroy(bullet, bulletLifetime);

        // Perform a raycast to check for collisions along the bullet's path
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        //{
        //    // Check if the bullet hit something
        //    if (hit.collider != null)
        //    {
        //        // Handle the collision, e.g., deal damage to the object hit
        //        // You can access the hit object using hit.collider.gameObject
        //    }
        //}
    }
}