﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeckService.factories
{
    public static class CardShuffler
    {
        private static Random rng = new Random();
        public static IList<T> Shuffle<T>( IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
