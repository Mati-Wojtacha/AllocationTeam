namespace AllocationTeamAPI.Dtos
{
    public class CombinationResultResponse<T>
    {
        internal object Item2;

        public int Id { get; set; }
        public List<T> FirstHalf { get; set; }
        public List<T> SecondHalf { get; set; }

        public CombinationResultResponse(int id, List<T> firstHalf, List<T> secondHalf)
        {
            Id = id;
            FirstHalf = firstHalf;
            SecondHalf = secondHalf;
        }
    }

}
