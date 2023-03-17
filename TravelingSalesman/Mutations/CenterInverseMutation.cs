﻿using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public class CenterInverseMutation : Mutation
    {
        private readonly Random rand;
        public CenterInverseMutation(Random rand)
        {
            this.rand = rand;
        }
        public override Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;

            int split = rand.Next(genomes.Length);

            return genomes.Take(split).Reverse().Concat(genomes.Skip(split).Reverse()).ToArray();
        }
    }
}
