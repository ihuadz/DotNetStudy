namespace EventHandlerSample
{
    public class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            /*EventHandler<ThresholdReachedEventArgs> 和 delegate void ThresholdReachedEventHandler(Object sender, ThresholdReachedEventArgs e) 两种方式 只有在极少数情况下才应声明委托，例如，在向无法使用泛型的旧代码提供类时，就需要如此*/

            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            //ThresholdReachedEventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //public event ThresholdReachedEventHandler ThresholdReached;
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    //public delegate void ThresholdReachedEventHandler(Object sender, ThresholdReachedEventArgs e);
}