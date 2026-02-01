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
    [SerializeField] private float _crowbarRadius = 0.55f;
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
    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void UseCrowbar()
    {
        Collider2D[] targetsObtained = Physics2D.OverlapCircleAll(transform.position, _crowbarRadius);
        for (int i = 0; i < targetsObtained.Length; i++)
        {
            DoorInteract door = targetsObtained[i].GetComponent<DoorInteract>();
            if (door != null)
            {
                door.BreakDownDoor();
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.papayaWhip;
        
        Gizmos.DrawWireSphere(transform.position, _crowbarRadius);
    }
}
