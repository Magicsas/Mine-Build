using UnityEngine;

public class AssembleFromComponents : MonoBehaviour
{
    public Component ComponentOne;
    public Component ComponentTwo;

    public MineItemsController mineItemsController;
    public int FirstComponentCount;
    public int SecondComponentCount;
    public int RequiredFirstComponentForCooking = 1;
    public int RequiredSecondComponentCooking = 1;

    private void Update()
    {
        CalculateAndCook();
    }

    private void CalculateAndCook()
    {
        if (ComponentTwo != null)
        {
            FirstComponentCount = ComponentOne.ObjectInCount;
            SecondComponentCount = ComponentTwo.ObjectInCount;

            //������, ������� ��������� �������� ������ � ����������� ��������
            int minCookedMeat = Mathf.Min(FirstComponentCount / RequiredFirstComponentForCooking, SecondComponentCount / RequiredSecondComponentCooking);
            mineItemsController.MaxItemsToSpawn = minCookedMeat;
        }

        //���� ��������� ����
        if(ComponentTwo == null)
        {
            FirstComponentCount = ComponentOne.ObjectInCount;
            mineItemsController.MaxItemsToSpawn = FirstComponentCount;
        }
    }
}
