using System;
using System.Collections.Generic;
using System.Text;


namespace AI_02 {
    class Graph {
        // всего комбинаций (9! / 2)
        public const int COMBINS = 181440;

        public int TotalCombinations {
            get { return COMBINS; }
        }

        public class Node {
            public byte[] state = null;
            public List<Node> children = null;
            public Node parent = null;

            public Node(Node parent) {
                this.parent = parent;
            }
        }

        public Node head = null;
        private SortedDictionary<Int64, Node> hopen = new SortedDictionary<Int64, Node>();
        private List<Int64> open = new List<Int64>(25000);
        // Список просмотренных вершин
        public SortedDictionary<Int64, Node> hclosed = new SortedDictionary<Int64, Node>();

        public static Int64 getHash(byte[] test) {
            return test[0] +           test[1] * 10 +       test[2] * 100 +
                   test[3] * 1000 +    test[4] * 10000 +    test[5] * 100000 +
                   test[6] * 1000000 + test[7] * 10000000 + test[8] * 100000000;
        }

        void ValidateState(byte[] test, Node temp) {
            Int64 hash = getHash(test);
            // попробуем найти такую комбинацию
            if (hclosed.ContainsKey(hash) == true) return;
            if (hopen.ContainsKey(hash) == true) return;

            if (temp.children == null) temp.children = new List<Node>();
            temp.children.Add(new Node(temp));
            Node t = temp.children[temp.children.Count - 1];
            t.state = test;
            hopen.Add(hash, t);
            open.Add(hash);

            return;
        }
        
        public void BuildGraph() {
            Node t1/*, t2*/;
            byte[] nst;
            Int64 hash;
            int free, col;

            if (hclosed.Count == COMBINS && head != null) return;

            // Зададим начальную комбинацию
            head = new Node(null);
            head.state = new byte[9];
            /******************************/
            /*  0  1  2      1  2  3
             *  3  4  5  =>  8     4
             *  6  7  8      7  6  5
             */
            // Указатель на состояние (для читаемости)
            nst = head.state;
            nst[0] = 1; nst[1] = 2; nst[2] = 3;
            nst[3] = 8; nst[4] = 0; nst[5] = 4;
            nst[6] = 7; nst[7] = 6; nst[8] = 5;

            hash = getHash(nst);
            hopen.Add(hash, head);
            open.Add(hash);
            while (open.Count > 0) {
                hash = open[0];
                open.RemoveAt(0);
                hopen.TryGetValue(hash, out t1);
                hopen.Remove(hash);

                free = Array.IndexOf(t1.state, (byte)0);
                if (free < 0) throw new ArgumentException("Нет свободной клетки");
                col = free % 3;
                // попробуем передвинуть сверху
                if (free > 2) {
                    nst = (byte[])t1.state.Clone();
                    nst[free] = nst[free - 3];
                    nst[free - 3] = 0;
                    ValidateState(nst, t1);
                }
                // попробуем передвинуть справа
                if (col != 2) {
                    nst = (byte[])t1.state.Clone();
                    nst[free] = nst[free + 1];
                    nst[free + 1] = 0;
                    ValidateState(nst, t1);
                }
                // попробуем передвинуть снизу
                if (free < 6) {
                    nst = (byte[])t1.state.Clone();
                    nst[free] = nst[free + 3];
                    nst[free + 3] = 0;
                    ValidateState(nst, t1);
                }
                // попробуем передвинуть слева
                if (col != 0) {
                    nst = (byte[])t1.state.Clone();
                    nst[free] = nst[free - 1];
                    nst[free - 1] = 0;
                    ValidateState(nst, t1);
                }
                hclosed.Add(hash, t1);
            }
        }
    }
}
