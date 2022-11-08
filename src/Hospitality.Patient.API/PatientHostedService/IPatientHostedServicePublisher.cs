namespace Hospitality.Patient.API.PatientHostedService
{
    public interface IPatientHostedServicePublisher
    {
        void SendMessage<T>(T message);
    }
}