namespace Hospitality.Patient.API.PatientHostedService
{
    public class AzurePatientHostedServicePublisher : IPatientHostedServicePublisher
    {
        private IConfiguration _configuration;
        private const string queueName = "patientservicetoemailservice";
        
        public AzurePatientHostedServicePublisher(IConfiguration configuration)
            => _configuration = configuration;
        
        public async void SendMessage<T>(T message)
            => await (new QueueClient(_configuration["ConectionStringRabbit"], queueName)).SendMessageAsync(JsonConvert.SerializeObject(message));
    }
}
