namespace DailyProgrammer
{
    public interface IChallenge<T>
    {
        T GetResult(object input);
    }
}
