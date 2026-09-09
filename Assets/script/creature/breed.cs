using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Breed
{
    List<Gene> enfant = new List<Gene>();
    
    public List<Gene> selectGene(List<Gene> parent1, List<Gene> parent2)
    {
        bool goodToContinue = false;
        
        while(!goodToContinue){
            foreach (Gene g in parent1)
            {
                if (g.pickchance > Random.Range(0, 10))
                {
                    enfant.Add(g);
                }
            }

            foreach (Gene g in parent2)
            {
                if (g.pickchance > Random.Range(0, 10))
                {
                    enfant.Add(g);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                int specificGeneNumber = 0;
                foreach (Gene g in enfant)
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

    public void PickActiveGenes(List<Gene> enfant)
    {
        
    }
}
