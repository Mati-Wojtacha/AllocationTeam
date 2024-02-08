using AllocationTeamAPI.Dtos;

namespace AllocationTeamAPI.Services
{
    public class CombinationService
    {
        private List<Tuple<int, List<int>, List<int>>> _GenerateCombinations(int nInput)
        {
            int lastIndex = 0;
            if (nInput % 2 != 0)
            {
                nInput += 1;
                lastIndex = nInput;
            }
            int[] input = Enumerable.Range(1, nInput).ToArray();
            List<List<int>> result = new List<List<int>>();
            int n = input.Length;
            for (int i = 0; i < (1 << n); i++)
            {
                List<int> combination = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        combination.Add(input[j]);
                    }
                }
                if (combination.Count == input.Length / 2)
                {
                    if (lastIndex != 0)
                    {
                        combination.Remove(lastIndex);
                    }
                    result.Add(combination);
                }
            }

            List<List<int>> firstHalf = result.Take(result.Count / 2).ToList();
            List<List<int>> secondHalf = result.Skip(result.Count / 2).Take(result.Count / 2).ToList();
            secondHalf.Reverse();

            List<Tuple<int, List<int>, List<int>>> combined = new List<Tuple<int, List<int>, List<int>>>();

            for (int i = 0; i < firstHalf.Count; i++)
            {
                combined.Add(new Tuple<int, List<int>, List<int>>(i + 1, firstHalf[i], secondHalf[i]));
            }

            return combined;
        }

        public List<CombinationResult<string>> CombinationsToString(string[] tableNames)
        {
            int nInput = tableNames.Length;
            var combinations = _GenerateCombinations(nInput);
            List<CombinationResult<string>> stringList = new List<CombinationResult<string>>();

            foreach (var combination in combinations)
            {
                int id = combination.Item1;
                List<string> firstHalfStrings = combination.Item2.Select(i => tableNames[i - 1]).ToList();
                List<string> secondHalfStrings = combination.Item3.Select(i => tableNames[i - 1]).ToList();
                // Tworzymy nowy obiekt CombinationResult, ale z uwagi na kontekst zadania, może być konieczne dostosowanie lub utworzenie nowej klasy
                stringList.Add(new CombinationResult<string>   (id, firstHalfStrings, secondHalfStrings)); // To prawdopodobnie wymaga dostosowania
            }

            return stringList;
        }
        public List<CombinationResult<int>> GenerateCombinations(int nInput)
        {
            var combinations = _GenerateCombinations(nInput);
            List<CombinationResult<int>> intList = new List<CombinationResult<int>>();

            foreach (var combination in combinations)
            {
                int id = combination.Item1;
                // Przekazanie bezpośrednio list kombinacji bez konwersji
                List<int> firstHalfInts = combination.Item2; // Bezpośrednie przekazanie, bez konwersji
                List<int> secondHalfInts = combination.Item3; // Bezpośrednie przekazanie, bez konwersji

                intList.Add(new CombinationResult<int>(id, firstHalfInts, secondHalfInts));
            }

            return intList;
        }

    }
}

