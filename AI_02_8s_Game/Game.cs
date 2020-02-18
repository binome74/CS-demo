using System;
using System.Collections.Generic;
using System.Text;

namespace AI_02 {
    class Game {
        public Graph graph;

        public Game() {
            graph = new Graph();
        }

        public int TotalCombinations {
            get { return graph.TotalCombinations; }
        }

        public int NodesGenerated {
            get { return graph.hclosed.Count; }
        }

        public void BuildGraph() {
            if (graph.head == null) graph.BuildGraph();
        }

        public byte[] New() {
            // сделаем начальную расстановку
            byte[] st = new byte[9];
            int free, dir, col;
            st[0] = 1; st[1] = 2; st[2] = 3;
            st[3] = 8; st[4] = 0; st[5] = 4;
            st[6] = 7; st[7] = 6; st[8] = 5;

            // делаем случайные перестановки
            Random Rand = new Random();
            for (int i = 0; i < 5000; i++) {
                free = Array.IndexOf(st, (byte)0);
                col = free % 3;
                dir = Rand.Next(4);
                if (dir == 0) {
                    // вверх, если строка не первая
                    if (free < 3) continue;
                    st[free] = st[free - 3];
                    st[free - 3] = 0;
                } else if (dir == 1) {
                    // вправо, если столбец не последний
                    if (col == 2) continue;
                    st[free] = st[free + 1];
                    st[free + 1] = 0;
                } else if (dir == 2) {
                    // вниз, если строка не последняя
                    if (free > 5) continue;
                    st[free] = st[free + 3];
                    st[free + 3] = 0;
                } else {
                    // влево, если столбец не первый
                    if (col == 0) continue;
                    st[free] = st[free - 1];
                    st[free - 1] = 0;
                }
            }

            return st;
        }

        public bool haveWon(byte[] state) {
            if (Graph.getHash(state) == Graph.getHash(graph.head.state)) return true;
            return false;
        }

        public byte[] stepUp(byte[] state) {
            Int64 hash = Graph.getHash(state);
            Graph.Node node;
            if (graph.hclosed.ContainsKey(hash) == false) {
                throw new ArgumentOutOfRangeException("Такого состояния в графе нет");
            }
            if (graph.hclosed.TryGetValue(hash, out node) == false) {
                throw new Exception("Не удалось извлечь состояние");
            }
            if (node.parent == null) return null;
            return node.parent.state;
        }

    }
}
