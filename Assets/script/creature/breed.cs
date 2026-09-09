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
        List<Gene> checkingGenes = new List<Gene>();
        List<Gene> activeGenes = new List<Gene>();
        bool geneFound = false;
        int i = 0;
        
            
        foreach (Gene g in enfant)
        {
            for (int g2=1; g2<=enfant.Count; g2++)
            {
                    if (g.geneType == enfant[g2].geneType)
                    {
                        checkingGenes.Add(enfant[g2]);
                    }
            }

            if (checkingGenes.Count > 1)
            {
                while (!geneFound)
                {
                    List<Gene> dominantGene = new List<Gene>();
                    List<Gene> possibleGene = new List<Gene>();
                    foreach (Gene g3 in checkingGenes)
                    {
                        if (g3.isDominant)
                        {
                            dominantGene.Add(g3);
                        }

                        if (g3 == g)
                        {
                            possibleGene.Add(g3);
                        }
                    }

                    if (dominantGene.Count > 1)
                    {
                        Gene currentGene = dominantGene[0];
                        for (int g4 = 1; g4 <= dominantGene.Count; g4++)
                        {
                            if (currentGene.dominantPercentage < dominantGene[g4].dominantPercentage)
                            {
                                currentGene = dominantGene[g4];
                            }
                        }
                        activeGenes.Add(currentGene);
                        geneFound = true;
                    }
                    else if (dominantGene.Count != 0)
                    {
                        activeGenes.Add(dominantGene[0]);
                        geneFound = true;
                    }
                }
            }
            else
            {
                activeGenes.Add(g);
            }
        }
        
        
    }
}
