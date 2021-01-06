namespace Scripts
{
    using UnityEngine;

    public class DistributorLinks : MonoBehaviour
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private Aim _aim;
        [SerializeField] private PullManager _pull;
        [SerializeField] private UIManager _uIManager;

        public Tower Tower => _tower;

        public Aim Aim => _aim;

        public PullManager Pull => _pull;

        public UIManager UI => _uIManager;


    }
}