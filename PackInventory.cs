Pack example = new Pack(20, 10);

string whatIsInPack;

example.Add(new Bow());

example.DisplayConstent();


whatIsInPack = example.ToString();
Console.WriteLine(whatIsInPack);

example.Add(new Arrow());

example.DisplayConstent();

example.Add(new Food());

example.DisplayConstent();

whatIsInPack = example.ToString();
Console.WriteLine(whatIsInPack);





class Pack
{
    public double MaxWeight{get; set;}
    public double MaxVolume{get; set;}

    public InventoryItem[] InventoryItems{get; set;}

    public int ItemsNumber{get; set;}
    public double CurrentWeight{get; set;}
    public double CurrentVolume{get; set;}

    

    public Pack(double mWeight, double mVolume)
    {
        MaxVolume = mVolume;
        MaxWeight = mWeight;
        ItemsNumber = 0;
        CurrentWeight = 0;
        CurrentVolume = 0;
        InventoryItems = new InventoryItem[300];
    }

    public bool Add(InventoryItem item)
    {
        if(CurrentVolume + item.Volume > MaxVolume){return false;}
        if(CurrentWeight + item.Weight > MaxWeight){return false;}

        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        InventoryItems[ItemsNumber] = item;
        ItemsNumber ++;

        Console.WriteLine($"{item.ToString()} succesfully added");
        return true;
        
    }

    public void DisplayConstent()
    {
        Console.WriteLine($"Max Weight: {MaxWeight}   Max Volume: {MaxVolume}\n");
        Console.WriteLine($"Current Weight: {(float)CurrentWeight}   Current Volume: {(float)CurrentVolume}\n");

    }

    public override string ToString()
    {
        string insidePack ="The pack contains ";
        if(ItemsNumber == 0)
        {
            insidePack = "The pack is empty";
        }
        else
        {
            for(int i = 0; i < ItemsNumber; i++)
            {
                insidePack += InventoryItems[i].ToString() + ", ";
            }
        }
        return insidePack;
    }
}


class InventoryItem
{
    public double Weight{get;set;}
    public double Volume{get;set;}

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }

}


class Arrow : InventoryItem
{   
    public override string ToString()=>"Arrow";
    public Arrow() : base(0.1, 0.05){}
}

class Bow : InventoryItem
{
    public override string ToString()=>"Bow";
    public Bow() : base(1, 4){}
}

class Rope : InventoryItem
{
    public override string ToString()=>"Rope";
    public Rope() : base(1, 1.5){}
}

class Water : InventoryItem
{
    public override string ToString()=>"Water";
    public Water() : base(2, 3){}
}

class Food : InventoryItem
{
    public override string ToString()=>"Food";
    public Food() : base(1, 0.1){}
}

class Sword : InventoryItem
{
    public override string ToString()=>"Sword";
    public Sword() : base(5, 3){}
}
