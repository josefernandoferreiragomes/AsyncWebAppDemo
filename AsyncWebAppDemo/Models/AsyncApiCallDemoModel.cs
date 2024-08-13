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
            System.DateTime dateTimeInit = System.DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
           
            //full sync
            using (var httpclient = new HttpClient())
            {
                try
                {
                    AsyncWebAppDemo.ExternalApi.ExternalApiDemo client = new ExternalApi.ExternalApiDemo(BaseUrl, httpclient);
                    Task<ICollection<WeatherForecast>> output;
                    //1st call
                    OutputMessages.Add("1st call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"1st call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //2nd call
                    OutputMessages.Add("2nd call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"2nd call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //3rd call
                    OutputMessages.Add("3rd call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"3rd call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //4th call
                    OutputMessages.Add("4th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"4th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //5th call
                    OutputMessages.Add("5th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"5th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //6th call
                    OutputMessages.Add("6th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"6th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //7th call
                    OutputMessages.Add("7th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"7th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //8th call
                    OutputMessages.Add("8th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"8th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //9th call
                    OutputMessages.Add("9th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"9th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                    //10th call
                    OutputMessages.Add("10th call sent");
                    output = client.GetWeatherForecastAsync();
                    OutputMessages.Add($"10th call returned: {output.Result.FirstOrDefault().TemperatureC}");
                }
                catch (Exception exp)
                {
                    OutputMessages.Add(exp.Message);
                }
            }


            System.DateTime dateTimeEnd = System.DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }
        public async Task GetApiCallAsync()
        {
            System.DateTime dateTimeInit = System.DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");
            
            //async
            using (var httpclient = new HttpClient())
            {
                try
                {
                    AsyncWebAppDemo.ExternalApi.ExternalApiDemo client = new ExternalApi.ExternalApiDemo(BaseUrl, httpclient);
                    ICollection<WeatherForecast> output;
                    //1st call
                    OutputMessages.Add("1st call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"1st call returned: {output.FirstOrDefault().TemperatureC}");
                    //2nd call
                    OutputMessages.Add("2nd call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"2nd call returned: {output.FirstOrDefault().TemperatureC}");
                    //3rd call
                    OutputMessages.Add("3rd call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"3rd call returned: {output.FirstOrDefault().TemperatureC}");
                    //4th call
                    OutputMessages.Add("4th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"4th call returned: {output.FirstOrDefault().TemperatureC}");
                    //5th call
                    OutputMessages.Add("5th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"5th call returned: {output.FirstOrDefault().TemperatureC}");
                    //6th call
                    OutputMessages.Add("6th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"6th call returned: {output.FirstOrDefault().TemperatureC}");
                    //7th call
                    OutputMessages.Add("7th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"7th call returned: {output.FirstOrDefault().TemperatureC}");
                    //8th call
                    OutputMessages.Add("8th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"8th call returned: {output.FirstOrDefault().TemperatureC}");
                    //9th call
                    OutputMessages.Add("9th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"9th call returned: {output.FirstOrDefault().TemperatureC}");
                    //10th call
                    OutputMessages.Add("10th call sent");
                    output = await client.GetWeatherForecastAsync();
                    OutputMessages.Add($"10th call returned: {output.FirstOrDefault().TemperatureC}");
                }
                catch(Exception exp)
                {
                    OutputMessages.Add(exp.Message);                    
                }
            }
            System.DateTime dateTimeEnd = System.DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

        public async Task GetApiCallConcurrent()
        {
            System.DateTime dateTimeInit = System.DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            //concurrent
            using (var httpclient = new HttpClient())
            {
                AsyncWebAppDemo.ExternalApi.ExternalApiDemo client = new ExternalApi.ExternalApiDemo(BaseUrl, httpclient);
                ICollection<WeatherForecast> output;
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

                output = await task1;                
                OutputMessages.Add($"1st call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task2;
                OutputMessages.Add($"2nd call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task3;
                OutputMessages.Add($"3rd call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task4;
                OutputMessages.Add($"4th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task5;
                OutputMessages.Add($"5th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task6;
                OutputMessages.Add($"6th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task7;
                OutputMessages.Add($"7th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task8;
                OutputMessages.Add($"8th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task9;
                OutputMessages.Add($"9th call returned: {output.FirstOrDefault().TemperatureC}");
                output = await task10;
                OutputMessages.Add($"10th call returned: {output.FirstOrDefault().TemperatureC}");
            }
            System.DateTime dateTimeEnd = System.DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }
      

        public async Task GetApiCallConcurrentOptimized()
        {
            System.DateTime dateTimeInit = System.DateTime.Now;
            OutputMessages.Add($"start time: {dateTimeInit.ToLongTimeString()}");

            //concurrent optimized
            using (var httpclient = new HttpClient())
            {
                AsyncWebAppDemo.ExternalApi.ExternalApiDemo client = new ExternalApi.ExternalApiDemo(BaseUrl, httpclient);
                ICollection<WeatherForecast> output;
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

                var serviceCallTasks = new List<Task<ICollection<WeatherForecast>>>() {task1, task2, task3, task4, task5, task6, task7, task8, task9, task10};

                while (serviceCallTasks.Count > 0)
                {
                    Task<ICollection<WeatherForecast>> finishedTask = await Task.WhenAny(serviceCallTasks);
                    output = finishedTask.Result;
                    OutputMessages.Add($"call returned: {output?.FirstOrDefault()?.TemperatureC}");
                    await finishedTask;
                    serviceCallTasks.Remove(finishedTask);
                }
               
            }
            System.DateTime dateTimeEnd = System.DateTime.Now;
            OutputMessages.Add($"end time: {dateTimeEnd.ToLongTimeString()}");
            OutputMessages.Add($"time taken / total milis: {(dateTimeEnd.Subtract(dateTimeInit)).TotalMilliseconds.ToString()} / total seconds: {(dateTimeEnd.Subtract(dateTimeInit)).TotalSeconds.ToString()}");
        }

      

      
    }
}
