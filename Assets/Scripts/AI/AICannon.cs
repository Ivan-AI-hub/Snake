namespace Scripts
{
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    public class AICannon : MonoBehaviour
    {
        private List<Vector2> _path = new List<Vector2>();
        private AIControll _aIControll;

        [SerializeField] private Tank _tank;
        [SerializeField] private GameObject _target;

        private void Start()
        {
            _aIControll = GetComponent<AIControll>();
            _path = _aIControll.GetPath(_target.transform.position);
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(transform.position, _path[_path.Count - 1]) > 0.5f)
            {
                Vector2 xTank = new Vector2(transform.position.x, 0);
                Vector2 yTank = new Vector2(0, transform.position.y);
                Vector2 xPath = new Vector2(_path[_path.Count - 1].x, 0);
                Vector2 yPath = new Vector2(0, _path[_path.Count - 1].y);

                if (Vector2.Distance(xTank,xPath) > Vector2.Distance(yTank, yPath))
                {
                    if(xTank.x <= xPath.x)
                    {
                        RotateToGrad(270);
                        _tank.Move(0, 1);
                    }
                    else
                    {
                        RotateToGrad(90);
                        _tank.Move(0, 1);
                    }
                }
                else
                {
                    if(yTank.y <= yPath.y)
                    {
                        RotateToGrad(0);
                        _tank.Move(0, 1);
                    }
                    else
                    {
                        RotateToGrad(180);
                        _tank.Move(0, 1);
                    }
                }
            }
            else
            {
                _path = _aIControll.GetPath(_target.transform.position);
            }
        }

        private void Move()
        {
            
        }

        private void RotateToGrad(float grad)
        {
            if (_tank.transform.rotation.z != grad)
                _tank.transform.eulerAngles = new Vector3(0, 0, grad);
        }
    }
}