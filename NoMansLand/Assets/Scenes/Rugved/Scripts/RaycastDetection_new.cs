using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection_new : MonoBehaviour
{
        public string tagName;
        public Transform player; // Reference to the player's transform
        public LayerMask obstacleLayer; // Layer mask for obstacles

        private void FixedUpdate()
        {
            if (RaycastDetect())
            {
                print("Found a body");
            }
        }

        // Raycast direction is from enemy position to player position
        public bool RaycastDetect()
        {
            if (player == null)
            {
                Debug.LogError("Player transform not assigned in the inspector.");
                return false;
            }

            RaycastHit hit;

            // Calculate the direction from the enemy position to the player's position
            Vector3 raycastDirection = player.position - transform.position;

            // Visualize the ray in the Unity Editor
            Debug.DrawRay(transform.position, raycastDirection, Color.green);

            // Check for obstacles between the enemy and player
            if (Physics.Raycast(transform.position, raycastDirection, out hit, Mathf.Infinity, obstacleLayer))
            {
                // If there is an obstacle, don't detect the player
                if (hit.transform.CompareTag("ObstacleTag"))
                {
                    return false;
                }
            }

            // Check for the player without being blocked by obstacles
            if (Physics.Raycast(transform.position, raycastDirection, out hit) && hit.transform.CompareTag(tagName))
            {
                return true;
            }

            return false;
        }
    }

