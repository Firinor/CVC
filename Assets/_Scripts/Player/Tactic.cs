using System.Collections.Generic;

public class Tactic
{
    private List<TaсticStep> tactic;

    public int WorkersLimit { get; private set; } = 2;
    public int WarriorsLimit { get; private set; }
    
}