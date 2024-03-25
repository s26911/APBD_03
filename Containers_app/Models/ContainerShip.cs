namespace Kontenery_app.Models;

public class ContainerShip
{
    private List<Container> Containers;
    public double MaxSpeedKnots { get; set; }
    public int MaxContainersCount { get; set; }
    public double MaxContainersMass { get; set; }
    private static int _index = 1;
    public string SerialNumber { get; set; }

    public ContainerShip(double maxSpeedKnots, int maxContainersCount, double maxContainersMass)
    {
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainersCount = maxContainersCount;
        MaxContainersMass = maxContainersMass;
        Containers = new List<Container>();
        SerialNumber = "S-" + _index++;
    }

    public bool LoadContainer(Container container)
    {
        if(Containers.Contains(container))
            Console.WriteLine("This container is already on ship");
        else if(Containers.Count >=  MaxContainersCount)
            Console.WriteLine("Container ship is full and cannot load more containers!(COUNT)");
        else
        {
            double weight = 0;
            Containers.ForEach(c=> weight += c.LoadMassKg + c.OwnWeightKg);
            
            if(weight + container.OwnWeightKg + container.LoadMassKg > MaxContainersMass)
                Console.WriteLine("Container ship is full and cannot load more containers!(MASS)");
            else
            {
                Containers.Add(container);
                return true;
            }
        }

        return false;
    }
    public void LoadContainer(List<Container> containers)
    {
        foreach (var c in containers)
        {
            LoadContainer(c);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public Container? RemoveContainer(string serialNum)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == serialNum)
            {
                Container container = Containers[i];
                Containers.Remove(container);
                return container;
            }
        }

        return null;
    }

    public void ReplaceContainer(string onShip, Container toReplace)
    {
        Container removed = RemoveContainer(onShip);
        if (removed == null)
        {
            Console.WriteLine("Container to be replaced was not found on ship");
            return;
        }

        if (!LoadContainer(toReplace))  // adding the container
        {
            Console.WriteLine("Given container couldn't fit on ship! Aborting...");
            LoadContainer(removed);
        }
    }

    public void MoveContainerBetweenShips(ContainerShip target, string toMoveSerialNum)
    {
        Container removed = RemoveContainer(toMoveSerialNum);
        if (removed == null)
        {
            Console.WriteLine("Container to be replaced was not found on ship");
            return;
        }
        if (!target.LoadContainer(removed))  // adding the container
        {
            Console.WriteLine("Given container couldn't fit on target ship! Aborting...");
            LoadContainer(removed);
        }
    }

    public override string ToString()
    {
        String s = "Container ship "+ SerialNumber +":" +
                   "\nMax speed [knots]: " + MaxSpeedKnots +
                   "\nMax containers count: " + MaxContainersCount +
                   "\nMax containers mass [kg]: " + MaxContainersMass+
                   "\nContents:";
        foreach (var c in Containers)
        {
            s += "\n\t" + c.SerialNumber;
        }

        return s+ "\n";
    }
}