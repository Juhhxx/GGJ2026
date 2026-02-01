using NaughtyAttributes;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _firecracker;
    [SerializeField] private GameObject _dogTreat;

    private void Update()
    {
        
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void ThrowFirecracker() => ThrowItem(_firecracker);
    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void ThrowDogTreat() => ThrowItem(_dogTreat);
    private void ThrowItem(GameObject selectedItem)
    {
        GameObject instantiatedItem = Instantiate(selectedItem, transform.position, quaternion.identity);
        ThrowableItem thrownItem = instantiatedItem.GetComponent<ThrowableItem>();
        thrownItem.InitialImpulse(_playerMovement.Direction);
    }
}
