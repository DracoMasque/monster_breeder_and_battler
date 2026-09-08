using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class breed
{
    List<gene> enfant = new List<gene>();
    
    public List<gene> selectGene(List<gene> parent1, List<gene> parent2)
    {
        bool goodToContinue = false;
        
        while(!goodToContinue){
            foreach (gene g in parent1)
            {
                if (g.pickchance > Random.Range(0, 10))
                {
                    enfant.Add(g);
                }
            }

            foreach (gene g in parent2)
            {
                if (g.pickchance > Random.Range(0, 10))
                {
                    enfant.Add(g);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                int specificGeneNumber = 0;
                foreach (gene g in enfant)
                {
                    if (g.geneType == (TypeGene)Enum.GetValues(typeof(TypeGene)).GetValue(i))
                    {
                        specificGeneNumber++;
                    }

                }
                if (specificGeneNumber != 0)
                {
                    goodToContinue = true;
                }else if (specificGeneNumber == 0)
                {
                    goodToContinue = false;
                }
            }
        }
        return enfant;
    }
    
    public 
}
