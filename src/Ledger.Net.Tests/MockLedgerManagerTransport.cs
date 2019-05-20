﻿using Ledger.Net.Requests;
using Ledger.Net.Responses;
using System;
using System.Threading.Tasks;

namespace Ledger.Net.Tests
{
    internal class MockLedgerManagerTransport : IHandlesRequest
    {
        public Task<TResponse> SendRequestAsync<TResponse, TRequest>(TRequest request)
            where TResponse : ResponseBase
            where TRequest : RequestBase
        {
            switch (request)
            {
                case BitcoinAppGetPublicKeyRequest bitcoinAppGetPublicKeyRequest:
                    if (bitcoinAppGetPublicKeyRequest.Ins == Constants.BTCHIP_INS_GET_WALLET_PUBLIC_KEY)
                    {
                        ResponseBase bitcoinAppGetPublicKeyResponse = new BitcoinAppGetPublicKeyResponse(new byte[] { 78, 2, 80, 12, 244, 122, 65, 92, 56, 119, 215, 232, 56, 1, 60, 35, 147, 20, 185, 198, 91, 78, 62, 117, 162, 25, 19, 255, 233, 204, 129, 81, 102, 61, 238, 147, 158, 220, 54, 184, 123, 156, 123, 78, 122, 236, 27, 225, 87, 8, 80, 6, 155, 86, 68, 243, 33, 82, 110, 29, 19, 89, 145, 208, 235, 108, 34, 51, 78, 121, 68, 102, 117, 111, 71, 107, 56, 100, 86, 97, 103, 122, 97, 67, 118, 106, 72, 57, 122, 74, 111, 70, 88, 86, 100, 68, 86, 86, 53, 87, 109, 189, 71, 99, 138, 245, 30, 191, 210, 130, 5, 213, 10, 88, 174, 204, 194, 59, 13, 84, 21, 234, 220, 130, 247, 113, 225, 226, 235, 135, 102, 113, 45, 144, 0 });

                        return Task.FromResult((TResponse)bitcoinAppGetPublicKeyResponse);
                    }
                    break;
            }

            throw new NotImplementedException();
        }
    }
}