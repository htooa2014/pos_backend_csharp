﻿using System;
using System.Collections.Generic;

namespace DotNet7.PosBackendApi.DbService.DbModels;

public partial class TblShop
{
    public int ShopId { get; set; }

    public string ShopCode { get; set; } = null!;

    public string ShopName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string Address { get; set; } = null!;
}
