﻿using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Hopfield_Network
{
    internal class Network
    {
        public Neuron[] neuron = new Neuron[9];
        public int[] output = new int[9];

        public Network(int[] w1, int[] w2, int[] w3, int[] w4, int[] w5, int[] w6, int[] w7, int[] w8, int[] w9)
        {
            neuron[0] = new Neuron(w1);
            neuron[1] = new Neuron(w2);
            neuron[2] = new Neuron(w3);
            neuron[3] = new Neuron(w4);
            neuron[4] = new Neuron(w5);
            neuron[5] = new Neuron(w6);
            neuron[6] = new Neuron(w7);
            neuron[7] = new Neuron(w8);
            neuron[8] = new Neuron(w9);

        }

        public int Threshold(int threshold)
        {
            return (threshold >= 0) ? 1 : -1;
        }

        public void Activation(int[] pattern)
        {
            output = pattern;
            int[] previous = new int[9];
            int[] current = new int[9] {-1,-1,-1,-1,-1,-1,-1,-1,-1};
            //int[] current = new int[9];
            //var previouses = new List<int[]>() { current };
            //var currents = new List<int[]>();
            int i = 0, k = 0;
            while (!(k == 9 && i == 9))
            {
                if (k == 9 && i != 9)
                {
                    k = 0;
                    i = 0;
                }

                if (previous.SequenceEqual(current))
                    i += 1;

                previous = current;
               // previouses.Add(previous);
                AsyncUpdate(output);
                current = output;
                //currents.Add(current)

                k++;    
            }
        }

        public void AsyncUpdate(int[] pattern)
        {
            for (int i = 0; i < 9; i++)
            {
                neuron[i].activation = neuron[i].Act(9, pattern);
                output[i] = Threshold(neuron[i].activation);
            }
        }
    }
}