using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace ProductsApi.Services
{
    public class CloudWatchMetricsService
    {
        private readonly IAmazonCloudWatch _cloudWatch;

        public CloudWatchMetricsService(IAmazonCloudWatch cloudWatch)
        {
            _cloudWatch = cloudWatch;
        }

        public async Task SendApiCallMetricAsync()
        {
            var request = new PutMetricDataRequest
            {
                Namespace = "ProductApi",
                MetricData = new List<MetricDatum>
                {
                    new MetricDatum
                    {
                        MetricName = "ApiCallCount",
                        Unit = StandardUnit.Count,
                        Value = 1,
                    }
                }
            };

            await _cloudWatch.PutMetricDataAsync(request);
        }
    }
}
