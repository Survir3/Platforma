using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SearchTargetTransition : Transition
{
    [SerializeField] float _minDistanceSearch;
    [SerializeField] float _maxDistanceSearch;
    [SerializeField] LayerMask _layerMask;

    private void Update()
    {
        NeedTransit = TrySearchTarget();
    }

    private bool TrySearchTarget()
    {
        var pointSearchLeft = new Vector2(transform.position.x - _minDistanceSearch, transform.position.y);
        var pointSearchRight = new Vector2(transform.position.x + _minDistanceSearch, transform.position.y);

        var foundPlayer = SearchPlayerInDirection(pointSearchLeft, Vector2.left);

        if (foundPlayer)
        {
            return foundPlayer;
        }
            
        foundPlayer = SearchPlayerInDirection(pointSearchRight, Vector2.right);

        return foundPlayer;   
    }

    private bool SearchPlayerInDirection(Vector2 origin, Vector2 direction)
    {
        int minCountHits=1;
        int firstHit = 0;
        Player player;
        ZoneAttackTarget zone;

        List<RaycastHit2D> hits = Physics2D.RaycastAll(origin, direction, _maxDistanceSearch, _layerMask).ToList();

        var filteredHits = hits.Where(hit => hit.collider.TryGetComponent<Player>(out player)
                                  || hit.collider.TryGetComponent<ZoneAttackTarget>(out zone)).ToList();


        if (filteredHits.Count >= minCountHits)
        {
            return filteredHits[firstHit].collider.TryGetComponent<Player>(out player);
        }

        return false;            
    }
}
