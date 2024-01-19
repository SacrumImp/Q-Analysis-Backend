using System.Collections.Generic;
using System.Linq;



namespace q_analysis_math.QVectorStructures
{
    public class QVectorElement
    {
        public int ConnectionLevel { get; }
        public List<Simplex> Simplices = new List<Simplex>();
        public int Value
        {
            get
            {
                return QConnectedElements.Count;
            }
        }

        public QVectorElement(int connectionLevel)
        {
            ConnectionLevel = connectionLevel;
        }

        public List<List<Simplex>> QConnectedElements
        {
            get
            {
                var connectedElements = new List<List<Simplex>>();
                // Если симплексов нет, то сразу ноль
                if (Simplices.Count == 0) return connectedElements;

                // TODO: Пересмотреть алгоритм, потому как он далек от оптимальности

                // Сначала размещаем все симплексы в списке компонент  связности
                Simplices.ForEach(simplex =>
                {
                    if (connectedElements.Count == 0)
                    {
                        connectedElements.Add(new List<Simplex> { simplex });
                        return;
                    }
                    var isConnected = false;
                    for (int i = 0; i < connectedElements.Count; i++)
                    {
                        for (int j = 0; j < connectedElements[i].Count; j++)
                        {
                            var connections = 0;
                            for (int r = 0; r < connectedElements[i][j].Relations.Length; r++)
                            {
                                connections += simplex.Relations[r].IsConnected(connectedElements[i][j].Relations[r]) ? 1 : 0;
                            }
                            if (connections > ConnectionLevel)
                            {
                                isConnected = true;
                                connectedElements[i].Add(simplex);
                                break;
                            }
                        }
                        if (isConnected) break;
                    }
                    if (!isConnected)
                    {
                        connectedElements.Add(new List<Simplex> { simplex });
                    }
                });

                // Проверяем связность остальных компонентов
                var hasNewConnection = true;
                while (hasNewConnection)
                {
                    hasNewConnection = false;
                    var updConnectedElements = new List<List<Simplex>>();
                    var skipList = new List<int>();
                    for (int i = 0; i < connectedElements.Count; i++)
                    {
                        if (skipList.Any(ind => ind == i))
                        {
                            continue;
                        }
                        for (int j = i + 1; j < connectedElements.Count; j++)
                        {
                            if (skipList.Any(ind => ind == j))
                            {
                                continue;
                            }
                            var isConnected = false;
                            foreach (Simplex simplexX in connectedElements[i])
                            {
                                foreach (Simplex simplexY in connectedElements[j])
                                {
                                    var connections = 0;
                                    for (int r = 0; r < simplexX.Relations.Length; r++)
                                    {
                                        connections += simplexX.Relations[r].IsConnected(simplexY.Relations[r]) ? 1 : 0;
                                    }
                                    if (connections > ConnectionLevel)
                                    {
                                        isConnected = true;
                                        break;
                                    }
                                }
                                if (isConnected)
                                {
                                    break;
                                }
                            }
                            if (isConnected)
                            {
                                connectedElements[i].AddRange(connectedElements[j]);
                                skipList.Add(j);
                                hasNewConnection = true;
                            }
                        }
                        updConnectedElements.Add(connectedElements[i]);
                    }
                    connectedElements = updConnectedElements;
                }

                return connectedElements;
            }
        }

        public QVectorElement(int connectionLevel, List<Simplex> simplices)
        {
            ConnectionLevel = connectionLevel;
            Simplices = simplices;
        }

        public void Add(Simplex simplex)
        {
            Simplices.Add(simplex);
        }

    }
}
