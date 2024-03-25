namespace Kontenery_app.Models;

public class ContainerShip
{
    private List<Container> Containers;
    public double MaxSpeed { get; set; }
    public int MaxContainersCount { get; set; }
    public double MaxContainersMass { get; set; }
}