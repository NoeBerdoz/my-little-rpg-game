using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    private EnnemyPathfinding ennemyPathfinding;

    private void Awake() {
        ennemyPathfinding = GetComponent<EnnemyPathfinding>();
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
            ennemyPathfinding.MoveTo(roamPosition);
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
