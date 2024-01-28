namespace AsyncWebAppDemo.Models
{
    public class AsyncDemoModel
    {
        public AsyncDemoModel()
        {
            OutputMessages = new List<string>();
        }
        // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
        internal class Bacon { }
        internal class Coffee { }
        internal class Egg { }
        internal class Juice { }
        internal class Toast { }

        public List<string> OutputMessages { get; set; }

        public void CookBreakfast()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
            Coffee cup = PourCoffee();
            OutputMessages.Add("coffee is ready");

            Egg eggs = FryEggs(2);
            OutputMessages.Add("eggs are ready");

            Bacon bacon = FryBacon(3);
            OutputMessages.Add("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            OutputMessages.Add("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }
        public async Task CookBreakfastIntermediate()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
            Coffee cup = await PourCoffeeAsync();
            OutputMessages.Add("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            OutputMessages.Add("eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            OutputMessages.Add("bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            await ApplyButterAsync(toast);
            await ApplyJamAsync(toast);
            OutputMessages.Add("toast is ready");

            Juice oj = await PourOJAsync();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task CookBreakfastConcurrently()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            Coffee cup = await PourCoffeeAsync();
            OutputMessages.Add("coffee is ready");
            
            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Egg eggs = await eggsTask;
            OutputMessages.Add("eggs are ready");
            
            Bacon bacon = await baconTask;
            OutputMessages.Add("bacon is ready");
            
            Toast toast = await toastTask;
            
            await ApplyButterAsync(toast);
            await ApplyJamAsync(toast);
            OutputMessages.Add("toast is ready");

            Juice oj = await PourOJAsync();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task CookBreakfastConcurrentOptimized()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            Coffee cup = await PourCoffeeAsync();
            OutputMessages.Add("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            OutputMessages.Add("eggs are ready");

            Bacon bacon = await baconTask;
            OutputMessages.Add("bacon is ready");

            Toast toast = await toastTask;            
            OutputMessages.Add("toast is ready");

            Juice oj = await PourOJAsync();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task CookBreakfastConcurrentlyOptimizedAll()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            Coffee cup = await PourCoffeeAsync();
            OutputMessages.Add("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            
            //will remove tasks from the list until all are campleted
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    OutputMessages.Add("Eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    OutputMessages.Add("Bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    OutputMessages.Add("Toast is ready");
                }
                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = await PourOJAsync();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task CookBreakfastConcurrentOptimizedException()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            Coffee cup = await PourCoffeeAsync();
            OutputMessages.Add("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsyncException(2);

            Egg eggs = await eggsTask;
            OutputMessages.Add("eggs are ready");

            Bacon bacon = await baconTask;
            OutputMessages.Add("bacon is ready");

            Toast toast = await toastTask;
            OutputMessages.Add("toast is ready");

            Juice oj = await PourOJAsync();
            Console.WriteLine("oj is ready");
            OutputMessages.Add("Breakfast is ready!");
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        #region Async

        private static async Task<Toast> ToastBreadAsyncException(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3002);
            Console.WriteLine("Fire! Toast is ruined!");
            throw new InvalidOperationException("The toaster is on fire");
            await Task.Delay(1000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
        private async Task<Toast> MakeToastWithButterAndJamAsyncException(int number)
        {
            var toast = await ToastBreadAsyncException(number);
            await ApplyButterAsync(toast);
            await ApplyJamAsync(toast);

            return toast;
        }

        private async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private async Task<Juice> PourOJAsync()
        {
            OutputMessages.Add("Pouring orange juice");
            return new Juice();
        }

        private async Task ApplyJamAsync(Toast toast) =>
            OutputMessages.Add("Putting jam on the toast");

        private async Task ApplyButterAsync(Toast toast) =>
            OutputMessages.Add("Putting butter on the toast");
        private async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                OutputMessages.Add("Putting a slice of bread in the toaster");
            }
            OutputMessages.Add("Start toasting...");
            await Task.Delay(3002);
            OutputMessages.Add("Remove toast from toaster");

            return new Toast();
        }
        private async Task<Bacon> FryBaconAsync(int slices)
        {
            OutputMessages.Add($"putting {slices} slices of bacon in the pan");
            OutputMessages.Add("cooking first side of bacon...");
            await Task.Delay(4003);
            for (int slice = 0; slice < slices; slice++)
            {
                OutputMessages.Add("flipping a slice of bacon");
            }
            OutputMessages.Add("cooking the second side of bacon...");
            await Task.Delay(4003);
            OutputMessages.Add("Put bacon on plate");

            return new Bacon();
        }

        private async Task<Egg> FryEggsAsync(int howMany)
        {
            OutputMessages.Add("Warming the egg pan...");
            await Task.Delay(3004);
            OutputMessages.Add($"cracking {howMany} eggs");
            OutputMessages.Add("cooking the eggs ...");
            await Task.Delay(3005);
            OutputMessages.Add("Put eggs on plate");

            return new Egg();
        }

        private async Task<Coffee> PourCoffeeAsync()
        {
            OutputMessages.Add("Pouring coffee");
            return new Coffee();
        }

        #endregion

        #region Sync
        private Juice PourOJ()
        {
            OutputMessages.Add("Pouring orange juice");
            return new Juice();
        }
        private void ApplyJam(Toast toast) =>
            OutputMessages.Add("Putting jam on the toast");

        private void ApplyButter(Toast toast) =>
            OutputMessages.Add("Putting butter on the toast");

        private Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                OutputMessages.Add("Putting a slice of bread in the toaster");
            }
            OutputMessages.Add("Start toasting...");
            Task.Delay(3002).Wait();
            OutputMessages.Add("Remove toast from toaster");

            return new Toast();
        }

        private Bacon FryBacon(int slices)
        {
            OutputMessages.Add($"putting {slices} slices of bacon in the pan");
            OutputMessages.Add("cooking first side of bacon...");
            Task.Delay(4003).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                OutputMessages.Add("flipping a slice of bacon");
            }
            OutputMessages.Add("cooking the second side of bacon...");
            Task.Delay(4003).Wait();
            OutputMessages.Add("Put bacon on plate");

            return new Bacon();
        }

        private Egg FryEggs(int howMany)
        {
            OutputMessages.Add("Warming the egg pan...");
            Task.Delay(3004).Wait();
            OutputMessages.Add($"cracking {howMany} eggs");
            OutputMessages.Add("cooking the eggs ...");
            Task.Delay(3005).Wait();
            OutputMessages.Add("Put eggs on plate");

            return new Egg();
        }

        private Coffee PourCoffee()
        {
            OutputMessages.Add("Pouring coffee");
            return new Coffee();
        }
        #endregion
    }
}
