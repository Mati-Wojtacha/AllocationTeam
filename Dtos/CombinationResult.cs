namespace AllocationTeamAPI.Dtos
{
    public class CombinationResult<T>
    {
        public int Id { get; set; }
        public List<T> FirstHalf { get; set; }
        public List<T> SecondHalf { get; set; }

        public CombinationResult(int id, List<T> firstHalf, List<T> secondHalf)
        {
            Id = id;
            FirstHalf = firstHalf;
            SecondHalf = secondHalf;
        }
    }

}
