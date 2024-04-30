﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PosBackendApi.Models.Setup.Report
{
    public class MonthlyReportResponseModel
    {
        public List<ReportModel> Data { get; set; }
        public MessageResponseModel MessageResponse { get; set; }
    }
}
