namespace EventHandlerSample
{
    public class ThresholdReachedEventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}