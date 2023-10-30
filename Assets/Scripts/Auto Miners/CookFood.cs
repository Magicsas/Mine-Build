using UnityEngine;

public class CookFood : MonoBehaviour
{
    public Component ComponentOne;
    public Component ComponentTwo;

    public MineItemsController mineItemsController;
    public int FirstComponentCount;
    public int SecondComponentCount;
    public int requiredFirstComponentForCooking = 1;
    public int requiredSecondComponentCooking = 1;

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

            int minCookedMeat = Mathf.Min(FirstComponentCount / requiredFirstComponentForCooking, SecondComponentCount / requiredSecondComponentCooking);
            mineItemsController.maxItemsToSpawn = minCookedMeat;
        }

        if(ComponentTwo == null)
        {
            FirstComponentCount = ComponentOne.ObjectInCount;
            mineItemsController.maxItemsToSpawn = FirstComponentCount;
        }
    }
}
