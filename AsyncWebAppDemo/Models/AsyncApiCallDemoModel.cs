using AsyncWebAppDemo.ExternalApi;

namespace AsyncWebAppDemo.Models
{
    public class AsyncApiCallDemoModel
    {
        private const string BaseUrl = "https://localhost:7273";

        public AsyncApiCallDemoModel()
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

        public void GetApiCallSync()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
           
            //full sync
            using (var httpclient = new HttpClient())
            {
                try
                {
                    AsyncWebAppDemo.ExternalApi.ApiDemo client = new ExternalApi.ApiDemo(BaseUrl, httpclient);
                    //1st call
                    OutputMessages.Add("1st call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("1st call returned");
                    //2nd call
                    OutputMessages.Add("2nd call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("2nd call returned");
                    //3rd call
                    OutputMessages.Add("3rd call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("3rd call returned");
                    //4th call
                    OutputMessages.Add("4th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("4th call returned");
                    //5th call
                    OutputMessages.Add("5th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("5th call returned");
                    //6th call
                    OutputMessages.Add("6th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("6th call returned");
                    //7th call
                    OutputMessages.Add("7th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("7th call returned");
                    //8th call
                    OutputMessages.Add("8th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("8th call returned");
                    //9th call
                    OutputMessages.Add("9th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("9th call returned");
                    //10th call
                    OutputMessages.Add("10th call sent");
                    client.GetWeatherForecastAsync();
                    OutputMessages.Add("10th call returned");
                }
                catch (Exception exp)
                {
                    OutputMessages.Add(exp.Message);
                }
            }


            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }
        public async Task GetApiCallAsync()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
            
            //async
            using (var httpclient = new HttpClient())
            {
                try
                {
                    AsyncWebAppDemo.ExternalApi.ApiDemo client = new ExternalApi.ApiDemo(BaseUrl, httpclient);
                    //1st call
                    OutputMessages.Add("1st call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("1st call returned");
                    //2nd call
                    OutputMessages.Add("2nd call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("2nd call returned");
                    //3rd call
                    OutputMessages.Add("3rd call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("3rd call returned");
                    //4th call
                    OutputMessages.Add("4th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("4th call returned");
                    //5th call
                    OutputMessages.Add("5th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("5th call returned");
                    //6th call
                    OutputMessages.Add("6th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("6th call returned");
                    //7th call
                    OutputMessages.Add("7th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("7th call returned");
                    //8th call
                    OutputMessages.Add("8th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("8th call returned");
                    //9th call
                    OutputMessages.Add("9th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("9th call returned");
                    //10th call
                    OutputMessages.Add("10th call sent");
                    await client.GetWeatherForecastAsync();
                    OutputMessages.Add("10th call returned");
                }
                catch(Exception exp)
                {
                    OutputMessages.Add(exp.Message);                    
                }
            }
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task GetApiCallConcurrent()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            //concurrent
            using (var httpclient = new HttpClient())
            {
                AsyncWebAppDemo.ExternalApi.ApiDemo client = new ExternalApi.ApiDemo(BaseUrl, httpclient);
                //1st call
                OutputMessages.Add("1st call sent");
                Task<ICollection<WeatherForecast>> task1 = client.GetWeatherForecastAsync();
                //2nd call
                OutputMessages.Add("2nd call sent");
                Task<ICollection<WeatherForecast>> task2 = client.GetWeatherForecastAsync();
                //3rd call
                OutputMessages.Add("3rd call sent");
                Task<ICollection<WeatherForecast>> task3 = client.GetWeatherForecastAsync();
                //4th call
                OutputMessages.Add("4th call sent");
                Task<ICollection<WeatherForecast>> task4 = client.GetWeatherForecastAsync();
                //5th call
                OutputMessages.Add("5th call sent");
                Task<ICollection<WeatherForecast>> task5 = client.GetWeatherForecastAsync();
                //6th call
                OutputMessages.Add("6th call sent");
                Task<ICollection<WeatherForecast>> task6 = client.GetWeatherForecastAsync();
                //7th call
                OutputMessages.Add("7th call sent");
                Task<ICollection<WeatherForecast>> task7 = client.GetWeatherForecastAsync();
                //8th call
                OutputMessages.Add("8th call sent");
                Task<ICollection<WeatherForecast>> task8 = client.GetWeatherForecastAsync();
                //9th call
                OutputMessages.Add("9th call sent");
                Task<ICollection<WeatherForecast>> task9 = client.GetWeatherForecastAsync();
                //10th call
                OutputMessages.Add("10th call sent");
                Task<ICollection<WeatherForecast>> task10 = client.GetWeatherForecastAsync();

                await task1;
                OutputMessages.Add("1st call returned");
                await task2;
                OutputMessages.Add("2nd call returned");
                await task3;
                OutputMessages.Add("3rd call returned");
                await task4;
                OutputMessages.Add("4th call returned");
                await task5;
                OutputMessages.Add("5th call returned");
                await task6;
                OutputMessages.Add("6th call returned");
                await task7;
                OutputMessages.Add("7th call returned");
                await task8;
                OutputMessages.Add("8th call returned");
                await task9;
                OutputMessages.Add("9th call returned");
                await task10;
                OutputMessages.Add("10th call returned");
            }
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }
      

        public async Task CookBreakfastConcurrentlyOptimizedAll()
        {
            DateTime dateTimeInit = DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            //concurrent optimized
            using (var httpclient = new HttpClient())
            {
                AsyncWebAppDemo.ExternalApi.ApiDemo client = new ExternalApi.ApiDemo(BaseUrl, httpclient);
                //1st call
                OutputMessages.Add("1st call sent");
                Task<ICollection<WeatherForecast>> task1 = client.GetWeatherForecastAsync();
                //2nd call
                OutputMessages.Add("2nd call sent");
                Task<ICollection<WeatherForecast>> task2 = client.GetWeatherForecastAsync();
                //3rd call
                OutputMessages.Add("3rd call sent");
                Task<ICollection<WeatherForecast>> task3 = client.GetWeatherForecastAsync();
                //4th call
                OutputMessages.Add("4th call sent");
                Task<ICollection<WeatherForecast>> task4 = client.GetWeatherForecastAsync();
                //5th call
                OutputMessages.Add("5th call sent");
                Task<ICollection<WeatherForecast>> task5 = client.GetWeatherForecastAsync();
                //6th call
                OutputMessages.Add("6th call sent");
                Task<ICollection<WeatherForecast>> task6 = client.GetWeatherForecastAsync();
                //7th call
                OutputMessages.Add("7th call sent");
                Task<ICollection<WeatherForecast>> task7 = client.GetWeatherForecastAsync();
                //8th call
                OutputMessages.Add("8th call sent");
                Task<ICollection<WeatherForecast>> task8 = client.GetWeatherForecastAsync();
                //9th call
                OutputMessages.Add("9th call sent");
                Task<ICollection<WeatherForecast>> task9 = client.GetWeatherForecastAsync();
                //10th call
                OutputMessages.Add("10th call sent");
                Task<ICollection<WeatherForecast>> task10 = client.GetWeatherForecastAsync();

                var serviceCallTasks = new List<Task>() {task1, task2, task3, task4, task5, task6, task7, task8, task9, task10};

                while (serviceCallTasks.Count > 0)
                {
                    Task finishedTask = await Task.WhenAny(serviceCallTasks);
                    OutputMessages.Add("call returned");
                    await finishedTask;
                    serviceCallTasks.Remove(finishedTask);
                }
               
            }
            DateTime dateTimeEnd = DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

      

      
    }
}
