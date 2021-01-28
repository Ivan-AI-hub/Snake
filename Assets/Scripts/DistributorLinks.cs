namespace Scripts
{
    using UnityEngine;

    public class DistributorLinks : MonoBehaviour
    {
        [SerializeField] private PullManager _pull;
        [SerializeField] private UIManager _uIManager;
        [SerializeField] private Tank _playerTank;

        public Tank PlayerTank => _playerTank;
        public Tower Tower => _playerTank.Tower;
        public Aim Aim => _playerTank.Aim;
        public PullManager Pull => _pull;
        public UIManager UI => _uIManager;
    }
}