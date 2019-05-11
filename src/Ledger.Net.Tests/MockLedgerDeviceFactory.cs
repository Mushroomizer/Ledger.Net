﻿using Device.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ledger.Net.Tests
{
    public class MockLedgerDeviceFactory : IDeviceFactory
    {
        public DeviceType DeviceType => DeviceType.Hid;

        public List<string> DeviceIds { get; } = new List<string>() { "0x2c97" };

        public Task<IEnumerable<ConnectedDeviceDefinition>> GetConnectedDeviceDefinitionsAsync(FilterDeviceDefinition deviceDefinition)
        {
            return Task.FromResult(DeviceIds.Select(d => new ConnectedDeviceDefinition(d) { DeviceType = DeviceType.Hid, VendorId = 0x2c97, UsagePage = 0xffa0 }));
        }

        public IDevice GetDevice(ConnectedDeviceDefinition deviceDefinition)
        {
            return new MockLedgerDevice(DeviceIds.First());
        }
    }
}
