namespace Scripts
{
    using UnityEngine;

    public class DistributorLinks : MonoBehaviour
    {
        [SerializeField] private GameObject _aim;
        [SerializeField] private PullManager _pull;
        [SerializeField] private UIManager _uIManager;

        public GameObject Aim => _aim;

        public PullManager Pull => _pull;

        public UIManager UI => _uIManager;
    }
}