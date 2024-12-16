using System;
using System.Collections.Generic;

namespace MedicaidEligibilityEnquiryTool.Models;

public partial class UserDetailsMet
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public int ApiCount { get; set; }

    public int ApiThresholdLimit { get; set; }
}
