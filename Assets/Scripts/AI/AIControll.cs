namespace Scripts
{
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    public class AIControll : MonoBehaviour
    {
        private List<Vector2> _pathToTarget = new List<Vector2>();
        private List<Node> _checkedNodes = new List<Node>();
        private List<Node> _waitingNodes = new List<Node>();
        [SerializeField] private LayerMask _solidMask;

        public List<Vector2> GetPath(Vector2 target)
        {
            _pathToTarget = new List<Vector2>();
            _checkedNodes = new List<Node>();
            _waitingNodes = new List<Node>();

            Vector2 startPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
            Vector2 targetPosition = new Vector2(Mathf.Round(target.x), Mathf.Round(target.y));

            if (targetPosition == startPosition) return _pathToTarget;

            Node startNode = new Node(0, startPosition, targetPosition, null);
            _checkedNodes.Add(startNode);
            _waitingNodes.AddRange(GetNeightborNodes(startNode));

            while (_waitingNodes.Count > 0)
            {
                Node nodeToCheck = _waitingNodes.Where(x => x._f == _waitingNodes.Min(y => y._f)).FirstOrDefault();

                if (nodeToCheck._position == targetPosition)
                {
                    return CalculatePathFromNode(nodeToCheck);
                }

                bool walkable = !Physics2D.OverlapCircle(nodeToCheck._position, 0.7f, _solidMask);
                if (walkable)
                {
                    _waitingNodes.Remove(nodeToCheck);
                    if (!_checkedNodes.Where(x => x._position == nodeToCheck._position).Any())
                    {
                        _checkedNodes.Add(nodeToCheck);
                        _waitingNodes.AddRange(GetNeightborNodes(nodeToCheck));
                    }
                }
                else
                {
                    _waitingNodes.Remove(nodeToCheck);
                    _checkedNodes.Add(nodeToCheck);
                }
            }

            return _pathToTarget;

        }

        private List<Node> GetNeightborNodes(Node node)
        {
            List<Node> neightbor = new List<Node>();

            float offsetPosition = 1f;

            neightbor.Add(NewNodeAdd(node, offsetPosition, 0));
            neightbor.Add(NewNodeAdd(node, -offsetPosition, 0));
            neightbor.Add(NewNodeAdd(node, 0, offsetPosition));
            neightbor.Add(NewNodeAdd(node, 0, -offsetPosition));

            return neightbor;
        }

        private Node NewNodeAdd(Node parentNode, float offsetX, float offsetY)
        {
            Node node = new Node(parentNode._g,
                                 new Vector2(parentNode._position.x + offsetX, parentNode._position.y + offsetY),
                                 parentNode._targetPosition,
                                 parentNode);
            return node;
        }

        private List<Vector2> CalculatePathFromNode(Node node)
        {
            List<Vector2> path = new List<Vector2>();
            Node currentNode = node;

            while (currentNode._previousNode != null)
            {
                path.Add(new Vector2(currentNode._position.x, currentNode._position.y));
                currentNode = currentNode._previousNode;
            }

            return path;
        }

        private void OnDrawGizmos()
        {
            foreach (var item in _checkedNodes)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(new Vector2(item._position.x, item._position.y), 0.1f);
            }

                foreach (var item in _pathToTarget)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(new Vector2(item.x, item.y), 0.3f);
                }
        }

    }




    public class Node
    {
        public Vector2 _position;
        public Vector2 _targetPosition;
        public Node _previousNode;

        public int _f; // f = g + H
        public int _g; // растояние от старта до ноды
        private int _h; // рфстояние от ноды до цели

        public Node(int g, Vector2 nodePosition, Vector2 targetPosition, Node previousNode)
        {
            _position = nodePosition;
            _targetPosition = targetPosition;
            _previousNode = previousNode;
            _g = g;
            _h = (int)Mathf.Abs(_targetPosition.x - _position.x) + (int)Mathf.Abs(_targetPosition.y - _position.y);
            _f = _g + _h;
        }
    }
}