/********************************************************************
 *
 *  PROPRIETARY and CONFIDENTIAL
 *
 *  This file is licensed from, and is a trade secret of:
 *
 *                   AvePoint, Inc.
 *                   525 Washington Blvd, Suite 1400
 *                   Jersey City, NJ 07310
 *                   United States of America
 *                   Telephone: +1-201-793-1111
 *                   WWW: www.avepoint.com
 *
 *  Refer to your License Agreement for restrictions on use,
 *  duplication, or disclosure.
 *
 *  RESTRICTED RIGHTS LEGEND
 *
 *  Use, duplication, or disclosure by the Government is
 *  subject to restrictions as set forth in subdivision
 *  (c)(1)(ii) of the Rights in Technical Data and Computer
 *  Software clause at DFARS 252.227-7013 (Oct. 1988) and
 *  FAR 52.227-19 (C) (June 1987).
 *
 *  Copyright © 2023 AvePoint® Inc. All Rights Reserved. 
 *
 *  Unpublished - All rights reserved under the copyright laws of the United States.
 */
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Ave.WebJob.Common
{
    public sealed class D365ConnectionService
    {
        private ServiceClient clientService;
        private static readonly D365ConnectionService instance = null;
        private Dictionary<string, ServiceClient> clientServiceDictionary;
        private const int ConnectionTimeOutMinutes = 2;
        private readonly IConfiguration _config;

        public D365ConnectionService(IConfiguration config)
        {
            clientServiceDictionary = new Dictionary<string, ServiceClient>();
            _config = config;
        }

        public static D365ConnectionService Instance
        {
            get { return instance; }
        }

        public ServiceClient GetOrganizationService()
        {
            string connectionString = _config["CRMConnectString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("CRMConnectString");
            }
            if (!clientServiceDictionary.TryGetValue(connectionString, out clientService))
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
                clientService = new ServiceClient(connectionString);
                clientServiceDictionary.Add(connectionString, clientService);
            }
            return clientService;
        }

        public ServiceClient RenewOrganizationService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            clientService = new ServiceClient(connectionString);
            if (clientServiceDictionary.ContainsKey(connectionString))
            {
                clientServiceDictionary[connectionString] = clientService;
            }
            else
            {
                clientServiceDictionary.Add(connectionString, clientService);
            }
            return clientService;
        }
    }
}
