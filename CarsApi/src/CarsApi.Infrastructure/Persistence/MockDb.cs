using CarsApi.Domain.Entities;

namespace CarsApi.Infrastructure.Persistence;

internal static class MockDb
{
    public static List<Car?> Cars { get; private set; } =
    [
        new() { Vin = 1234, Brand = "Mercedes", Model = "GLE COUPÉ", PlateNumber = "ABC-121" },
        new() { Vin = 1235, Brand = "BMW", Model = "525", PlateNumber = "CAB-123" },
        new() { Vin = 1236, Brand = "Chevrolet", Model = "Corsa", PlateNumber = "BCA-121" },
        new() { Vin = 1237, Brand = "Fiat", Model = "Uno", PlateNumber = "BAC-123" },
        new() { Vin = 1238, Brand = "Chevrolet", Model = "Onix", PlateNumber = "CBA-121" }
    ];
}