namespace AsyncWebDemo.Site.Helpers
{
    public static class SlidingWindowHelper
    {
        /// <summary>
        /// Implement a sliding window algorithm for calculating the averages at each 5 days
        /// </summary>
        /// <param name="list"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static List<decimal> ProduceListOfAverageOfEveryDesiredAmountOfUnits (List<decimal> list, int units)
        {
            List<decimal> result = new List<decimal>();

            decimal sum = 0.0M;
            decimal average = 0.0M;

            for (int i = 0; i < list.Count; i++) 
            {
                sum += list[i];
                if(i>0 && (i+1) % units == 0)
                {
                    average = sum / (decimal)units;
                    result.Add(average);
                    sum = 0.0M;
                    average=0.0M;

                }
            }

            return result;
        }

        /// <summary>
        /// Implement a sliding window algorithm for looking at the last 5 days of stock prices
        /// </summary>
        /// <param name="list"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static List<decimal> ProduceListOfMovingAverage (List<decimal> list, int units)
        {
            List<decimal> result = new List<decimal>();

            decimal sum = 0.0M;
            decimal average = 0.0M;
            Queue<decimal> queue = new Queue<decimal>();
            bool started = false;
            for (int i = 0; i < list.Count; i++) 
            {
                queue.Enqueue(list[i]);
                if(i>0 && (i+1) % units == 0)
                {
                    started = true;
                }
                if (started)
                {
                    average = (decimal)queue.Sum() / (decimal)units;
                    result.Add(average);                   
                    average=0.0M;
                    queue.Dequeue();

                }

            }

            return result;
        }
    }
}
