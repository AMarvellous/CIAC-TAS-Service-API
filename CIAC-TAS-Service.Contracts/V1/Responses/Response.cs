﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public Response()
        {

        }

        public Response(T response)
        {
            Data = response;
        }
    }
}
