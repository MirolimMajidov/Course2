namespace SoftPrinciples;

public class Home
{
    public int Doors { get; init; }
    public int Windows { get; init; }
    public bool HasGarage { get; init; }
    public bool HasWall { get; init; }

    // public Home(int doors)
    // {
    //     Doors = doors;
    // }
    //
    // public Home(int doors, int windows)
    // {
    //     Doors = doors;
    //     Windows = windows;
    // }
    //
    // public Home(int doors, int windows, bool hasGarage)
    // {
    //     Doors = doors;
    //     Windows = windows;
    //     HasGarage = hasGarage;
    // }
}

public class HomeBuilder
{
    private int _doors;
    private int _windows;
    private bool _hasGarage;
    private bool _hasWall;

    public HomeBuilder WithDoors(int doors)
    {
        _doors = doors;

        return this;
    }
    
    public HomeBuilder WithWindows(int windows)
    {
        _windows = windows;

        return this;
    }
    
    public HomeBuilder WithGarage(bool hasGarage)
    {
        _hasGarage = hasGarage;

        return this;
    }
    
    public HomeBuilder WithWall(bool hasWall)
    {
        _hasWall = hasWall;

        return this;
    }

    public Home Build()
    {
        return new Home
        {
            Windows = _windows,
            Doors = _doors,
            HasGarage = _hasGarage,
            HasWall = _hasWall
        };
    }
}