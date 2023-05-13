using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoamingRoutine());
        
    }

    private IEnumerator RoamingRoutine() {
        while (state == State.Roaming) 
        {
            // Get random position every 2 seconds
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition() {
        // get random direction x and y
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // normalized to make sure it's not going in a die out direction
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
